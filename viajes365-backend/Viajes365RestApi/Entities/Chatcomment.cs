using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes365RestApi.Entities
{
    public class Chatcomment : Base
    {
        [Key]
        public long ChatcommentId { get; set; }
        [Required]
        [StringLength(255)]
        public string Message { get; set; }
        
        [StringLength(50)]
        public string Status { get; set; }
        public bool IsResponse { get; set; }
        
        public long UserId { get; set; }
                
        public long ChatId { get; set; }
        public virtual Chat Chat { get; set; }

    }
}
