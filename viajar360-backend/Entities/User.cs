using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class User : Models.BaseModel
    {
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
        [StringLength(15)]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
    }
}