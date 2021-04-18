using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Dtos
{
     public class WeatherUpdateDto : Base
    {
        public long WeatherId { get; set; }
        public string Copyright { get; set; }
        public string Use { get; set; }
        public string Web { get; set; }
        public string Language { get; set; }
        public InformationDto Information { get; set; }
        public bool active;     
    }
}
