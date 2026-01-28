using AutoMapper;
using Pustok.Core.Entities;

namespace Pustok.Buisness.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>().ForMember(x=>x.ProfessionName, x=>x.MapFrom(x=>x.Profession.Name))
                                                .ReverseMap();


            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();

        }

    }
}
