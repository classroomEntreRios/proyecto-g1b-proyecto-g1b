using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    public class Attraction : Base
    {
        [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        //public Location Location { get; set; }

        public ICollection<Tour_attraction> Tour_Attractions { get; set; }
    }
}
