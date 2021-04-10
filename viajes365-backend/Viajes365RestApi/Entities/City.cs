using System.ComponentModel.DataAnnotations;

namespace Viajes365RestApi.Entities
{
    public class City : Base
    {
        [Key]
        public long CityId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Code { get; set; }
    }
}
