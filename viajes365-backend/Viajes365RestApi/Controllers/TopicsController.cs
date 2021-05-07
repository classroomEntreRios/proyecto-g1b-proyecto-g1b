using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Filters;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;

namespace Viajes365RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;
        private IMapper _mapper;

        public TopicsController(DataContext context, IUriService uriService, IMapper mapper)
        {
            _context = context;
            _uriService = uriService;
            _mapper = mapper;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics([FromQuery] PaginationFilter filter)
        {
            List<TopicDto> topics = new List<TopicDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Topics.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<TopicDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Topics
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(t => t.User)
            .Include(t => t.Comments)
            .ToListAsync();
                result.ForEach(c => topics.Add(_mapper.Map<TopicDto>(c)));
                PagedResponse<List<TopicDto>> pagedResponse = Pagination.CreatePagedReponse<TopicDto>(topics, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDto>> GetTopic(long id)
        {
            try
            {
                var topic = await _context.Topics
                            .Include(t => t.User)
                            .Include(t => t.Comments)
                            .SingleAsync(t => t.TopicId == id);
                return Ok(new Response<TopicDto>(_mapper.Map<TopicDto>(topic)));
            }
            catch (System.Exception)
            {
                return NotFound(new Response<TopicDto>() { Message = "TOPICO NO ENCONTRADO", ErrorCode = 416 });
            }            
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(long id, Topic topic)
        {
            if (id != topic.TopicId)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(long id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TopicExists(long id)
        {
            return _context.Topics.Any(c => c.TopicId == id);
        }
    }
}