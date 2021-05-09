using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
    public class ChatChatcommentDto : Base
    {
        public long ChatId { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
