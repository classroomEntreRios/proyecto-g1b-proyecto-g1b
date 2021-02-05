using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajar360Api.Entities
{
    public enum RoleType
    {
        Anonymous, Registered, Moderator, Admin
    }

    public class Role : Models.BaseModel
    {
        [Key]
        public long RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { set; get; }
        public RoleType RoleType { set; get; }
        public ICollection<User> Users { get; set; }
    }
}
