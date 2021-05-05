using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Extensions;
using Viajes365RestApi.Filters;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;

namespace Viajes365RestApi.Controllers
{
    // [Authorize]
    // [ApiController]
    // [Authorization(adminrole)]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        const string adminrole = "Administrador";

        public PhotosController(DataContext context, IWebHostEnvironment env, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
            _uriService = uriService;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoDto>>> GetPhotos([FromQuery] PaginationFilter filter)
        {
            List<PhotoDto> photos = new List<PhotoDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Photos.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<PhotoDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Photos
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();
                result.ForEach(p => photos.Add(_mapper.Map<PhotoDto>(p)));
                PagedResponse<List<PhotoDto>> pagedResponse = Pagination.CreatePagedReponse<PhotoDto>(photos, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoDto>> GetPhoto(long id)
        {
            var photo = await _context.Photos.FindAsync(id);

            if (photo == null)
            {
                return NotFound(new Response<PhotoDto>() { Message = "FOTO NO ENCONTRADA", ErrorCode = 416 });
            }

            PhotoDto model = _mapper.Map<PhotoDto>(photo);
            return Ok(new Response<PhotoDto>(model));
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(long id, Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        
        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto([FromForm] PhotoUpdateDto photoDto)            
        {
            // photoDto.photo.Path = await UploadImage(photoDto.file, photoDto.category).Result;
            _context.Photos.Add(_mapper.Map<Photo>(photoDto));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoto", new { id = photoDto.photo.PhotoId }, photoDto);
        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(long id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(long id)
        {
            return _context.Photos.Any(p => p.PhotoId == id);
        }

        [HttpPost("UploadImage")]
        public async Task<string> UploadImage([FromForm] IFormFile file, [FromForm] string category)
        {
            string fName = file.FileName;
            string path = Path.Combine(_env.ContentRootPath, "MyStaticFiles", "Images", category, fName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return JsonSerializer.Serialize(new { path = Path.Combine("StaticFiles", "Images", category, fName) }); 
        }

        [HttpPost("UploadImages")]
        public Task<List<string>> UploadImages([FromForm] List<IFormFile> files, [FromForm] string category)
        {
            List<string> PathStrings = new List<string>();
            string fName;
            files.ForEach(async file =>
            {
                fName = file.FileName;
                string path = Path.Combine(_env.ContentRootPath, "MyStaticFiles", "Images", category, fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                PathStrings.Add(path);
            });

            return Task.FromResult(PathStrings); 
            
        }
    }
   
}
