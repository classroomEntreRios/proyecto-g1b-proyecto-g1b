using Abp.Authorization;
using Viajar365.Authorization.Roles;
using Viajar365.Authorization.Users;

namespace Viajar365.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
