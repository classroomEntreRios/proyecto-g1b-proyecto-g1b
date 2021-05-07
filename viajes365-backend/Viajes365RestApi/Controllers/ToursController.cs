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
    public class ToursController : ControllerBase
    {
        private IMapper _mapper;
        private IUriService _uriService;
        private readonly DataContext _context;
        const string adminrole = "Administrador";

        public ToursController(DataContext context, IMapper mapper, IUriService uriService)
        {
            _mapper = mapper;
            _context = context;
            _uriService = uriService;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours([FromQuery] PaginationFilter filter)
        {
            List<TourDto> tours = new List<TourDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Tours.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<TourDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Tours
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(t => t.Location)
            .Include(t => t.Attractions)
            .Include(t => t.Photos)
            .ToListAsync();
                result.ForEach(t => tours.Add(_mapper.Map<TourDto>(t)));
                PagedResponse<List<TourDto>> pagedResponse = Pagination.CreatePagedReponse<TourDto>(tours, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour(long id)
        {
            try
            {
                var tour = await _context.Tours
             .Include(t => t.Location)
             .Include(t => t.Attractions)
             .Include(t => t.Photos)
             .SingleAsync(t => t.TourId == id);
                return Ok(new Response<TourDto>(_mapper.Map<TourDto>(tour)));
            }
            catch (System.Exception)
            {
                return NotFound(new Response<TourDto>() { Message = "TOUR NO ENCONTRADO", ErrorCode = 416 });
            }

        }

        // GET: api/Attractions
        [HttpGet("location/{id}")]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetToursByLocationId(long id)
        {
            List<TourDto> tours = new List<TourDto>();

            var result = await _context.Tours.Where(a => a.LocationId == id).ToListAsync();
            result.ForEach(u => tours.Add(_mapper.Map<TourDto>(u)));

            return tours;
        }

        // PUT: api/tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(long id, TourDto model)
        {
            if (id != model.TourId)
            {
                return BadRequest();
            }

            // map model to entity and set id
            var tour = _mapper.Map<Tour>(model);
            tour.TourId = id;

            // Keep FK integrity Location Id 1L is default no location
            if (tour.LocationId == 0) { tour.LocationId = 1L; }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.TourId }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(long id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(long id)
        {
            return _context.Tours.Any(e => e.TourId == id);
        }
    }
}
