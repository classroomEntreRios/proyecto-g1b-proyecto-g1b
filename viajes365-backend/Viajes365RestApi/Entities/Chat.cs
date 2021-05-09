using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes365RestApi.Entities
{
    public class Chat : Base
    {
        [Key]
        public long ChatId { get; set; }
        [Required]
        [StringLength(40)]
        public string Nick { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Status { get; set; }

        public ICollection<Chatcomment> Chatcomments { get; set; }
    }
}
