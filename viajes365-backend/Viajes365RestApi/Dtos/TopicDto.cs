using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
    public class TopicDto : Base
    {
        public long TopicId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public bool Pinned { get; set; }
        public long UserId { get; set; }
        public virtual UserForumDto User { get; set; }

        public ICollection<CommentDto> Comments { get; set; }
    }
}
