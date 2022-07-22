using AutoMapper;
using Coffe.Entities;
using Coffe.Models.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RequestCreateUserModel, User>()
                .ForMember(f => f.UserTypeId, f => f.MapFrom(d => d.UserTypeId));
        }
    }
}
