using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Viajes365RestApi.Entities
{
    public class Attraction : Base
    {
         [Key]
        public long AttractionId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }
        // [ForeignKey("FK_Attraction_Location_LocationId")]
        // public long LocationId { get; set; }
        // public virtual Location Location { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
