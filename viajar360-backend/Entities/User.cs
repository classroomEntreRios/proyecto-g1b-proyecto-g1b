using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajar360Api.Entities
{
    public class User : Models.BaseModel
    {
        [Key]
        public long UserId { get; set; }
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
        [StringLength(15)]
        public string UserName { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [ForeignKey("FK_Users_Roles_RoleId")]
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}