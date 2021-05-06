using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    public class Topic : Base
    {
        [Key]
        public long TopicId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Summary { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        public bool Pinned { get; set; }
               
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
