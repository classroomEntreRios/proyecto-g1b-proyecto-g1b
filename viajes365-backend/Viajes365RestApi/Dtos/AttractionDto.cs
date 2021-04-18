

namespace Viajes365RestApi.Dtos
{
    public class AttractionDto
    {
        public long AttractionId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Note { get; set; }
        public int Rating { get; set; }

        public long LocationId { get; set; }
        public virtual LocationDto Location { get; set; }
        public bool Active { get; set; }

    }
}
