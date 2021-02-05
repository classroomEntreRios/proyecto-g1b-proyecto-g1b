using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajar360Api.Entities;
using Viajar360Api.Models;

namespace Viajar360Api.Models
{
    public class RoleModel : BaseModel
    {
        public long RoleId { get; set; }
        public string RoleName { set; get; }
        public RoleType RoleType { set; get; }
    }
}
