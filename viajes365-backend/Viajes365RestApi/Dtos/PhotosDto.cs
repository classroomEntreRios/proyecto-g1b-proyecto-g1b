namespace Viajes365RestApi.Dtos
{
    public class PhotoDto
    {
        public long PhotoId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        // public long LocationId { get; set; }
        //public virtual Location Location { get; set; }
        public bool Active { get; set; }
    }
}