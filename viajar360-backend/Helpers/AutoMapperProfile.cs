using AutoMapper;
using Viajar360Api.Entities;
using Viajar360Api.Models;
using Viajar360Api.Models.Roles;
using Viajar360Api.Models.Users;

namespace Viajar360Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<UpdateRoleModel, Role>();
        }
    }
}