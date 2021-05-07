using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
namespace Viajes365RestApi.Entities
{
    public class Photo : Base
    {
        [Key]
        public long PhotoId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        //[ForeignKey("FK_Photo_Location_LocationId")]
        //public long LocationId { get; set; }
        //public virtual Location Location { get; set; }
        //public ICollection<Attraction> Attractions { get; set; }
    }
}
