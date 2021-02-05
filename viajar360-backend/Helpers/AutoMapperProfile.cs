using AutoMapper;
using Viajar360Api.Entities;
using Viajar360Api.Models.Users;

namespace Viajar360Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}