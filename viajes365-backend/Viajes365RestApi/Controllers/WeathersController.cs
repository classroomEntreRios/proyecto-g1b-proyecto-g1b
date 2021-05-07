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
    [ApiController]
    [Route("api/[controller]")]
    public class WeathersController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IUriService _uriService;
        private IWeatherService _weatherService;
        private readonly DataContext _context;
             

        public WeathersController(
            DataContext context,
            IMapper mapper,
            IUriService uriService,
            IWeatherService weatherService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
            _weatherService = weatherService;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetWeathers([FromQuery] PaginationFilter filter)
        {
            List<Weather> weathers = new List<Weather>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Weathers.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<Weather>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Weathers
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(w => w.Information)
            .Include(w => w.Locality)
            .Include(w => w.Days.OrderBy(w => w.Name))
            .Include(w => w.Hours.OrderBy(w => w.Name))
            .ToListAsync();
                result.ForEach(w => weathers.Add(w));
                PagedResponse<List<Weather>> pagedResponse = Pagination.CreatePagedReponse<Weather>(weathers, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Weathers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(long id)
        {
            try
            {
                var weather = await _context.Weathers
                     .Include(w => w.Information)
                     .Include(w => w.Locality)
                     .Include(w => w.Days.OrderBy(w => w.Name))
                     .Include(w => w.Hours.OrderBy(w => w.Name))
                     .SingleAsync(w => w.WeatherId == id);

                return Ok(new Response<Weather>(weather));
            }
            catch (Exception)
            {
                return NotFound(new Response<Weather>() { Message = "CLIMA NO ENCONTRADO", ErrorCode = 416 });
            }

        }
        
        // PUT: api/Weathers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(long id, [FromBody] WeatherUpdateDto model)
        {
            if (id != model.WeatherId)
            {
                return BadRequest();
            }
            var weather = _mapper.Map<Weather>(model);
            weather.WeatherId = id;

            _context.Entry(weather).State = EntityState.Modified;

            // Avoiding FK errors
            _context.Entry(weather).Property(w => w.InformationId).IsModified = false;
            _context.Entry(weather).Property(w => w.LocalityId).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
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

        // POST: api/Weathers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{CityId}")]
        public async Task<ActionResult<Weather>> PostWeather([FromBody] WeatherDto model, [FromRoute] long CityId)
        {
            
            if (CityId.ToString().Length > 0)
            {
               model = await _weatherService.GetByCityId(CityId);
            }
           
            // map model to entity
            var weather = _mapper.Map<Weather>(model);
         
            _context.Weathers.Add(weather);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeather", new { id = weather.WeatherId }, weather);
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(long id)
        {
            var weather = await _context.Weathers.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            weather = await _context.Weathers
               .Include(w => w.Information)
               .Include(w => w.Locality)
               .Include(w => w.Days.OrderBy(w => w.Name))
               .Include(w => w.Hours.OrderBy(w => w.Name))
               .SingleAsync(w => w.WeatherId == id);

            _context.Informations.Remove(weather.Information);
            _context.Localities.Remove(weather.Locality);

            _context.Weathers.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExists(long id)
        {
            return _context.Weathers.Any(c => c.WeatherId == id);
        }
    }
}
