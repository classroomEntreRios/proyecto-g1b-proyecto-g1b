using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Viajar360Api.Entities
{
    [NotMapped]
    public class RoleUser
    {
        public long RolesRoleId { get; set; }
        public long UsersUserId { get; set; }
        public object RolesId { get; internal set; }
        public object UserId { get; internal set; }
    }
}
