using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Extensions;
using Viajes365RestApi.Filters;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;

namespace Viajes365RestApi.Controllers
{
    // [Authorize]
    // [Authorization(adminrole)]
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;
        const string adminrole = "Administrador";

        public CitiesController(DataContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities([FromQuery] PaginationFilter filter)
        {
            List<City> cities = new List<City>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Cities.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<City>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Cities
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();
                result.ForEach(c => cities.Add(c));
                PagedResponse<List<City>> pagedResponse = Pagination.CreatePagedReponse<City>(cities, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(long id)
        {
            try
            {
                var city = await _context.Cities.FindAsync(id);
                return Ok(new Response<City>(city));
            }
            catch (System.Exception)
            {
                return NotFound(new Response<City>() { Message = "CIUDAD NO ENCONTRADA", ErrorCode = 416 });
            }
 
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(long id, City city)
        {
            if (id != city.CityId)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.CityId }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(long id)
        {
            return _context.Cities.Any(c => c.CityId == id);
        }
    }
}
