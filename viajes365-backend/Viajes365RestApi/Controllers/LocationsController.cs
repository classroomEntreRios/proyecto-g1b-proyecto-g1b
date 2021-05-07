using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
    public class LocationsController : ControllerBase
    {
        private IMapper _mapper;
        private IUriService _uriService;
        private readonly DataContext _context;
        const string adminrole = "Administrador";

        public LocationsController(DataContext context, IMapper mapper, IUriService uriService)
        {
            _mapper = mapper;
            _context = context;
            _uriService = uriService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations([FromQuery] PaginationFilter filter)
        {
            List<LocationDto> locations = new List<LocationDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Locations.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<LocationDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Locations
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(l => l.City)
            .ToListAsync();
                result.ForEach(a => locations.Add(_mapper.Map<LocationDto>(a)));
                PagedResponse<List<LocationDto>> pagedResponse = Pagination.CreatePagedReponse<LocationDto>(locations, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }
        
        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetLocation(long id)
        {
            try
            {
                var location = await _context.Locations
                      .Include(l => l.City)
                      .SingleAsync(l => l.LocationId == id);
                LocationDto model = _mapper.Map<LocationDto>(location);
                return Ok(new Response<LocationDto>(model));
            }
            catch (Exception)
            {
                return NotFound(new Response<LocationDto>() { Message = "LOCACION NO ENCONTRADA", ErrorCode = 416 });
            }           
        }
        
        // PUT: api/locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(long id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.LocationId }, location);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(long id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(long id)
        {
            return _context.Locations.Any(e => e.LocationId == id);
        }
    }
}
