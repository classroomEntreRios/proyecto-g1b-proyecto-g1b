using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
namespace Viajes365RestApi.Entities
{
    public class Photos : Base
    {
         [Key]
        public long PhotosId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Path { get; set; }
       
        [ForeignKey("FK_Photos_Location_LocationId")]
        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
        public ICollections<Attractions> { get; set; }
    }
}
