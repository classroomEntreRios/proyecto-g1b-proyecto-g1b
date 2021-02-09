using System.Threading.Tasks;
using Abp.Application.Services;
using Viajar365.Authorization.Accounts.Dto;

namespace Viajar365.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
