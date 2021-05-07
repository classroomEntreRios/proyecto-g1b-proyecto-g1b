using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
    public class CommentDto : Base
    {
        public long CommentId { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public long TopicId { get; set; }
        public virtual TopicCommentDto Topic { get; set; }
        public long UserId { get; set; }
        public virtual UserForumDto User { get; set; }
    }
}
