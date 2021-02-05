using System.ComponentModel.DataAnnotations;

namespace Viajar360Api.Models.Users
{
    public class AuthenticateModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}