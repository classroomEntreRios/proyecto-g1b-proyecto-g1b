using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ChatcommentsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;

        public ChatcommentsController(DataContext context, IUriService uriService, IMapper mapper)
        {
            _context = context;
            _uriService = uriService;
            _mapper = mapper;
        }

        // GET: api/Chatcomments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatcommentDto>>> GetChatcomments([FromQuery] PaginationFilter filter, [FromQuery] long chatId)
        {
            List<ChatcommentDto> comments = new List<ChatcommentDto>();
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var totalElements = await _context.Chatcomments.CountAsync();

            if (totalElements == 0)
            {

                return NotFound(new PagedResponse<List<ChatcommentDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });

            }
            else
            {
                if (chatId == 0L)
                {
                    var result = await _context.Chatcomments
                        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                        .Take(validFilter.PageSize).ToListAsync();
                    result.ForEach(c => comments.Add(_mapper.Map<ChatcommentDto>(c)));
                }
                else
                {
                    var chat = await _context.Chats
                        .Include(c => c.Chatcomments)
                        .SingleAsync(c => c.ChatId == chatId);
                    if (chat == null)
                    {

                        return NotFound(new PagedResponse<List<ChatcommentDto>>() { Message = "NO HAY RESULTADOS CON LOS PARAMETROS INDICADOS", ErrorCode = 416 });
                    }
                    else
                    {
                        var result = chat.Chatcomments
                         .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                         .Take(validFilter.PageSize).ToList();
                        result.ForEach(c => comments.Add(_mapper.Map<ChatcommentDto>(c)));
                    }

                }

                PagedResponse<List<ChatcommentDto>> pagedResponse = Pagination.CreatePagedReponse<ChatcommentDto>(comments, validFilter, totalElements, _uriService, route);
                return Ok(pagedResponse);
            }
        }

        // GET: api/Chatcomments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatcommentDto>> GetChatcomment(long id)
        {
            try
            {
                var chatComment = await _context.Chatcomments
                            .Include(cc => cc.Chat)
                            .SingleAsync(cc => cc.ChatcommentId == id);
                return Ok(new Response<ChatcommentDto>(_mapper.Map<ChatcommentDto>(chatComment)));
            }
            catch (System.Exception)
            {
                return NotFound(new Response<ChatcommentDto>() { Message = "COMENTARIO NO ENCONTRADO", ErrorCode = 416 });
            }

        }

        // PUT: api/Chatcomments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(long id, Chatcomment chatComment)
        {
            if (id != chatComment.ChatcommentId)
            {
                return BadRequest();
            }

            _context.Entry(chatComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Chatcomments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chatcomment>> PostChatcomment(Chatcomment chatComment)
        {
            _context.Chatcomments.Add(chatComment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatcomment", new { id = chatComment.ChatcommentId }, chatComment);
        }

        // DELETE: api/Chatcomments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatcomment(long id)
        {
            var chatComment = await _context.Chatcomments.FindAsync(id);
            if (chatComment == null)
            {
                return NotFound();
            }

            _context.Chatcomments.Remove(chatComment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(long id)
        {
            return _context.Chatcomments.Any(cc => cc.ChatcommentId == id);
        }
    }
}
