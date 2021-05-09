using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
    public class ChatcommentDto : Base
    {
        public long ChatCommentId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public bool IsResponse { get; set; }
        public long UserId { get; set; }
        public virtual UserDto User { get; set; }
        public long ChatId { get; set; }
        public virtual ChatChatcommentDto Chat { get; set; }
    }
}
