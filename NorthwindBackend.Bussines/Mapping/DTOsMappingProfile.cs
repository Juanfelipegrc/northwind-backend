using AutoMapper;
using NorthwindBackend.Bussines.DTOs.Response;
using NorthwindBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.Mapping
{
    public class DTOsMappingProfile : Profile
    {
        public DTOsMappingProfile() 
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => CalculateAge(src.BirthDate)));

        
        }


        private static int? CalculateAge(DateTime? birthDate)
        {
            if (birthDate == null)
                return null;

            var today = DateTime.Today;
            int age = today.Year - birthDate.Value.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return age;

        }
    }
}
