using Abp.Application.Services;
using Viajar365.MultiTenancy.Dto;

namespace Viajar365.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

