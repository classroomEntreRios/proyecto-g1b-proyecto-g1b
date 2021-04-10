using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public byte Note { get; set; }
    }
}
