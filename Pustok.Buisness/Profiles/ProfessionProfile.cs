using AutoMapper;
using Pustok.Buisness.Dtos.ProfessionDtos;
using Pustok.Core.Entities;

namespace Pustok.Buisness.Profiles
{
    public class ProfessionProfile : Profile
    {
        public ProfessionProfile()
        {
            CreateMap<Profession, ProfessionGetDto>().ReverseMap();
            CreateMap<Profession, ProfessionCreateDto>().ReverseMap();
            CreateMap<Profession, ProfessionUpdateDto>().ReverseMap();
        }

    }
}
