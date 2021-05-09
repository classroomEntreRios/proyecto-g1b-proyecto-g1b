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
using Viajes365RestApi.Filters;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;
using Viajes365RestApi.Wrappers;

namespace Viajes365RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;
        private IMapper _mapper;

        public ChatsController(DataContext context, IUriService uriService, IMapper mapper)
        {
            _context = context;
            _uriService = uriService;
            _mapper = mapper;
        }

        // GET: api/Chats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatDto>>> GetChats([FromQuery] PaginationFilter filter)
        {
            List<ChatDto> chats = new List<ChatDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Chats.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<ChatDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                var result = await _context.Chats
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .Include(t => t.Chatcomments)
            .ToListAsync();
                result.ForEach(c => chats.Add(_mapper.Map<ChatDto>(c)));
                PagedResponse<List<ChatDto>> pagedResponse = Pagination.CreatePagedReponse<ChatDto>(chats, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Chats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatDto>> GetChat(long id)
        {
            try
            {
                var chat = await _context.Chats
                            .Include(t => t.Chatcomments)
                            .SingleAsync(t => t.ChatId == id);
                return Ok(new Response<ChatDto>(_mapper.Map<ChatDto>(chat)));
            }
            catch (System.Exception)
            {
                return NotFound(new Response<ChatDto>() { Message = "CHAT NO ENCONTRADO", ErrorCode = 416 });
            }
        }

        // PUT: api/Chats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(long id, Chat chat)
        {
            if (id != chat.ChatId)
            {
                return BadRequest();
            }

            _context.Entry(chat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatExists(id))
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

        // POST: api/Chats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(Chat chat)
        {
            _context.Chats.Add(chat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = chat.ChatId }, chat);
        }

        // DELETE: api/Chats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(long id)
        {
            var chat = await _context.Chats.FindAsync(id);
            if (chat == null)
            {
                return NotFound();
            }

            _context.Chats.Remove(chat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChatExists(long id)
        {
            return _context.Chats.Any(c => c.ChatId == id);
        }
    }
}
