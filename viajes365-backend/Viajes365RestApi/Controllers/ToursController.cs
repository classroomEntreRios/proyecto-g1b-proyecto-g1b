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
using Viajes365RestApi.Helpers;

namespace Viajes365RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Authorization(adminrole)]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private IMapper _mapper;
        private readonly DataContext _context;
        const string adminrole = "Administrador";

        public ToursController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourDto>>> GetTours()
        {
            List<TourDto> tours = new List<TourDto>();
            var result = await _context.Tours.Include(u => u.Location).ToListAsync();
            result.ForEach(u => tours.Add(_mapper.Map<TourDto>(u)));
            return tours;
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourDto>> GetTour (long id)
        {
            var toloc = await _context.Tours.Include(at => at.Location).ToListAsync();
            var tour = toloc.Find(to => to.TourId == id);

            if (tour == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TourDto>(tour);

            return result;

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
        public async Task<IActionResult> PutTour(long id, Tour tour)
        {
            if (id != tour.TourId)
            {
                return BadRequest();
            }

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
