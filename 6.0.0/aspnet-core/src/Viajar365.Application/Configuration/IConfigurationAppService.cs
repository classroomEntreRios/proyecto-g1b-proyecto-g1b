using System.Threading.Tasks;
using Viajar365.Configuration.Dto;

namespace Viajar365.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
