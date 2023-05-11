using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Core.Dtos.User;
using Users.Core.Dtos.Subscription;

namespace Users.Api.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDetailsDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
        }
    }
}
