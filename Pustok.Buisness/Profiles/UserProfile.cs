using AutoMapper;
using Pustok.Buisness.Dtos.UserDtos;
using Pustok.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Buisness.Profiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
        }

    }
}
