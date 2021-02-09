using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Viajar365.Configuration.Dto;

namespace Viajar365.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Viajar365AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
