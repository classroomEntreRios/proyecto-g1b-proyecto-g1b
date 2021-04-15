using System;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Viajes365RestApi.Entities
{
    public class Attractions : Base
    {
         [Key]
        public long AttractionsId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
        [ForeignKey("FK_Attractions_Location_LocationId")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public IEnumerator<Photos> { get; set; }
    }
}
