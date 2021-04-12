
namespace Viajes365RestApi.Dtos
{
    public class TourDto
    {
        public long TourId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Duration { get; set; }

        public long LocationId { get; set; }
        //public Location Location { get; set; }
    }
}
