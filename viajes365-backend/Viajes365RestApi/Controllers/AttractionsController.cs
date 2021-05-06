using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Extensions;
using Viajes365RestApi.Filters;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;

namespace Viajes365RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Authorization(adminrole)]
    [Route("api/[controller]")]
    public class AttractionsController : ControllerBase
    {
        private IMapper _mapper;
        private IUriService _uriService;
        private readonly DataContext _context;
        const string adminrole = "Administrador";

        public AttractionsController(DataContext context, IMapper mapper, IUriService uriService)
        {
            _mapper = mapper;
            _context = context;
            _uriService = uriService;
        }

        // GET: api/Attractions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttractionDto>>> GetAttractions([FromQuery] PaginationFilter filter)
        {
            List<AttractionDto> attractions = new List<AttractionDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Attractions.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<AttractionDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Attractions
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(a => a.Location)
            .Include(a => a.Photos)
            .Include(a => a.Tours)
            .ToListAsync();
                result.ForEach(a => attractions.Add(_mapper.Map<AttractionDto>(a)));
                PagedResponse<List<AttractionDto>> pagedResponse = Pagination.CreatePagedReponse<AttractionDto>(attractions, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }
            

        // GET: api/Attractions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AttractionDto>> GetAttraction(long id)
        {
            var attraction = await _context.Attractions
                .Include(a => a.Location)
                .Include(a => a.Photos)
                .Include(a => a.Tours)
                .SingleAsync(a => a.AttractionId == id);

            if (attraction == null)
            {
                return NotFound(new Response<AttractionDto>() { Message = "ATRACCION NO ENCONTRADA", ErrorCode = 416 });
            }

            AttractionDto model = _mapper.Map<AttractionDto>(attraction);
            return Ok(new Response<AttractionDto>(model));
        }
        
        // GET: api/Attractions
        [HttpGet("location/{id}")]
        public async Task<ActionResult<IEnumerable<AttractionDto>>> GetAttractionsByLocationId(long id)
        {
            List<AttractionDto> attractions = new List<AttractionDto>();

            var result = await _context.Attractions.Where(a => a.LocationId == id).ToListAsync();
            result.ForEach(u => attractions.Add(_mapper.Map<AttractionDto>(u)));

            return attractions;
        }

        // PUT: api/Attractions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttraction(long id, Attraction attraction)
        {
            if (id != attraction.AttractionId)
            {
                return BadRequest();
            }

            _context.Entry(attraction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttractionExists(id))
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

        // POST: api/Attractions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attraction>> PostAttraction(Attraction attraction)
        {
            _context.Attractions.Add(attraction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttraction", new { id = attraction.AttractionId }, attraction);
        }

        // DELETE: api/Attractions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttraction(long id)
        {
            var attraction = await _context.Attractions.FindAsync(id);
            if (attraction == null)
            {
                return NotFound();
            }

            _context.Attractions.Remove(attraction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttractionExists(long id)
        {
            return _context.Attractions.Any(e => e.AttractionId == id);
        }


    }
}
