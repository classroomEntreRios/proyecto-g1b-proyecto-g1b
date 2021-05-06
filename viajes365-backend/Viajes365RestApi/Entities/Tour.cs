using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Viajes365RestApi.Entities
{
    public class Tour : Base
    {
        [Key]
        public long TourId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string Summary { get; set; }
        [StringLength(20)]
        public string Duration { get; set; }

        [ForeignKey("Location")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Attraction> Attractions { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

    }
}
