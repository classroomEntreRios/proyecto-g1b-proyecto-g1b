using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
    public class ChatDto : Base
    {
        public long ChatId { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public ICollection<ChatcommentDto> Chatcomments { get; set; }
    }
}
