using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Viajar365.Authorization.Users;

namespace Viajar365.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
