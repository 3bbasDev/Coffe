using AutoMapper;
using Coffe.Entities;
using Coffe.Models.Users.Request;

namespace Coffe.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RequestCreateUserModel, User>()
                .ForMember(f => f.UserTypeId, d => d.MapFrom(f => f.UserTypeId));

            CreateMap<RequestUpdateUserModel, User>()
                .ForMember(f => f.UserTypeId, d => d.MapFrom(f => f.UserTypeId));
        }
    }
}
