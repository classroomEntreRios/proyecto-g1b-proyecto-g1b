using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public enum RoleType
    {
        Anonymous, Registered, Moderator, Admin
    }

    public class Role : Models.BaseModel
    {
        [StringLength(50)]
        public string RoleName { set; get; }
        public bool Active { set; get; }
        public RoleType RoleType { set; get; }
    }
}
