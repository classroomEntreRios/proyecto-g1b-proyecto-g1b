using Microsoft.AspNetCore.Http;

namespace Viajes365RestApi.Dtos
{
    public class PhotoUpdateDto
    {
        public PhotoDto photo { get; set; }
        public IFormFile file { get; set; }
        public string category { get; set; }
    }
}
