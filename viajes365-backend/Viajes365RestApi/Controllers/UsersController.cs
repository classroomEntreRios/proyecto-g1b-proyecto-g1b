﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Extensions;
using Viajes365RestApi.Handlers;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;

namespace Viajes365RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;
        const string adminrole = "Administrador";
        const string userrole = "Usuario";
        private string _mainrole;
        private long _userid;

        public UsersController(DataContext context,
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
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
                return await _userService.Create(user, model.Password, model.RoleId);

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
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            List<UserDto> users = new List<UserDto>();
            var result = await _context.Users.Include(u => u.Role).ToListAsync();
            result.ForEach(u => users.Add(_mapper.Map<UserDto>(u)));
            return users;
        }

        // Allow only self id for role user and any id for role admin
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(long id)
        {
            setAppUser();
            if (_mainrole == userrole && _userid != id)
            {
                return Unauthorized();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }


            UserDto model = _mapper.Map<UserDto>(user);
            return Ok(model);
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
