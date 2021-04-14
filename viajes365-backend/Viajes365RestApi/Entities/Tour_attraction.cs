using System.ComponentModel.DataAnnotations;

namespace Viajes365RestApi.Entities
{
    public class Tour_attraction
    {
        [Key]
        public long Tour_atractionId { get; set; }

        public long Tour_Id { get; set; }
        //public Tour Tour { get; set; }

        public long Attraction_Id { get; set; }
        //public Attraction Attraction { get; set; }

    }
}
