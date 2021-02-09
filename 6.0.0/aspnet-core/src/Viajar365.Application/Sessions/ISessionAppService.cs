using System.Threading.Tasks;
using Abp.Application.Services;
using Viajar365.Sessions.Dto;

namespace Viajar365.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
