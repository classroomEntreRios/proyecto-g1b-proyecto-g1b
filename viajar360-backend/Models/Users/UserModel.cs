using System;
using System.Collections.Generic;
using Viajar360Api.Entities;

namespace Viajar360Api.Models.Users
{
    public class UserModel : BaseModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
    }
}