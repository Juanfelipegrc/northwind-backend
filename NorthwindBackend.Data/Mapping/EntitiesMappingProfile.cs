using AutoMapper;
using NorthwindBackend.Data.Entities;
using NorthwindBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.Mapping
{
    public class EntitiesMappingProfile : Profile
    {
        public EntitiesMappingProfile()
        {

            //MAPPING

            CreateMap<UserDataModel, User>()
                .ConstructUsing(src => new User(src.Id, src.LastName, src.FirstName, src.Role));


            CreateMap<EmployeeDataModel, Employee>()
                .ConstructUsing(src => new Employee(
                    src.EmployeeId,
                    src.LastName,
                    src.FirstName,
                    src.Title,
                    src.TitleOfCourtesy,
                    src.BirthDate,
                    src.Address,
                    src.City,
                    src.Region,
                    src.Country,
                    src.HomePhone

                ));

            CreateMap<Employee, EmployeeDataModel>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id));
        }

    }
}
