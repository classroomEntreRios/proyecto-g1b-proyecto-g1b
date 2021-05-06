
using System.Collections.Generic;

namespace Viajes365RestApi.Dtos

{
    public class TourDto
    {
        public long TourId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Duration { get; set; }

        public long LocationId { get; set; }
        public virtual LocationDto Location { get; set; }
        public virtual ICollection<PhotoDto> Photos { get; set; }
        public virtual ICollection<AttractionDto> Attractions { get; set; }
        public bool Active { get; set; }

    }
}
