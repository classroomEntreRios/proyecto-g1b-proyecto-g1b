using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    public class Comment : Base
    {
        [Key]
        public long CommentId { get; set; }
        [Required]
        [StringLength(255)]
        public string Body { get; set; }
        
        public long TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
