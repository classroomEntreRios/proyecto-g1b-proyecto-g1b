using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Viajar365.MultiTenancy;

namespace Viajar365.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
