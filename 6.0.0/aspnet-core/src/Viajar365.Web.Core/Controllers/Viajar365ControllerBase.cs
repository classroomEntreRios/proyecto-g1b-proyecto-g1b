using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Viajar365.Controllers
{
    public abstract class Viajar365ControllerBase: AbpController
    {
        protected Viajar365ControllerBase()
        {
            LocalizationSourceName = Viajar365Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
