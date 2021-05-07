using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    public class Location : Base
    {
        [Key]
        public long LocationId { get; set; }
        [StringLength(100)]
        [Required]
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [StringLength(150)]
        public string FullAddress { get; set; }
        public string Note { get; set; }

        [ForeignKey("FK_Locations_Cities_CityId")]
        public long CityId { get; set; }
        public virtual City City { get; set; }

        // public ICollection<Tour> Tours { get; set; }
        // public ICollection<Attraction> Attractions { get; set; }
    }
}
