using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Extensions;
using Viajes365RestApi.Filters;
using Viajes365RestApi.Handlers;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;
using static System.Net.Mime.MediaTypeNames;

namespace Viajes365RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IUriService _uriService;
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;
        const string adminrole = "Administrador";
        const string userrole = "Usuario";
        private string _mainrole;
        private long _userid;

        public object filename { get; private set; }

        public UsersController(DataContext context,
            IUserService userService,
            IMapper mapper,
            IWebHostEnvironment env,
            IUriService uriService,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _env = env;
            _uriService = uriService;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserAuthenticateDto model)
        {
            var user = _userService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim("Role", user.Role.RoleName)
                }),
                // TODO make expiration time a Param 
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            
            // return basic user info and authentication token
            return Ok(new
            {
                UserId = user.UserId,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Token = tokenString,
                returnUrl = user.Role.RoleId == 2 ? "admin" : "/"
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserRegisterDto model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                User createdUser = await _userService.Create(user, model.Password, model.RoleId);
                // we need anonimous profile image
                string defaultProfileImage = Path.Combine(_env.ContentRootPath, "MyStaticFiles", "Images", "Avatars", "default-avatar.png");
                string path = Path.Combine(_env.ContentRootPath, "MyStaticFiles", "Images", "Avatars", "user-avatar" + createdUser.UserId + ".png");
                using (FileStream SourceStream = new FileStream(defaultProfileImage, FileMode.Open))
                {
                    using (FileStream DestinationStream = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                    }
                }
                // we need to create Photo from new file
                Photo photo = new Photo();
                photo.Name = "UserAvatar" + createdUser.UserId;
                photo.Summary = "Avatar Sin Foto";
                photo.Description = "Imagén de Perfil";
                photo.Active = true;
                photo.Path = Path.Combine("StaticFiles", "Images", "Avatars", "user-avatar" + createdUser.UserId + ".png"); ;
                _context.Photos.Add(photo);
                createdUser.Photo = photo;
                await _context.SaveChangesAsync();
                return createdUser;

            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // Allow list of users only for role admin
        [Authorization(adminrole)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] PaginationFilter filter)
        {
            List<UserDto> users = new List<UserDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Users.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<UserDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _userService.GetAll(validFilter);
                foreach (User u in result)
                {
                    users.Add(_mapper.Map<UserDto>(u));
                }   
                PagedResponse<List<UserDto>> pagedResponse = Pagination.CreatePagedReponse<UserDto>(users, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // Allow only self id for role user and any id for role admin
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(long id)
        {
            setAppUser();
            if (_mainrole == userrole && _userid != id)
            {
                return Unauthorized();
            }

            try
            {
                var user = await _userService.GetById(id);
                return Ok(new Response<UserDto>(_mapper.Map<UserDto>(user)));
            }
            catch (Exception)
            {
                return NotFound(new Response<UserDto>() { Message = "USUARIO NO ENCONTRADO", ErrorCode = 416 });
            }
        }

        // Allow only self id for role user and any id for role admin
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] UserUpdateDto model)
        {
            setAppUser();
            if (_mainrole == userrole && _userid != id)
            {
                return Unauthorized();
            }
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.UserId = id;

            try
            {
                // update user 
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // Allow only self id for role user and any id for role admin
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            setAppUser();
            if (_mainrole == userrole && _userid != id)
            {
                return Unauthorized();
            }
            _userService.Delete(id);
            return Ok();
        }

        private void setAppUser() {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            _mainrole = claimsIdentity.FindFirst("Role").Value;
            _userid = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
