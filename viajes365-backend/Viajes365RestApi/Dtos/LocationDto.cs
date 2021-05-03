namespace Viajes365RestApi.Dtos

{
    public class LocationDto
    {
        public long LocationId { get; set; }
        public string LocationName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FullAddress { get; set; }
        public byte Note { get; set; }
    }
}
