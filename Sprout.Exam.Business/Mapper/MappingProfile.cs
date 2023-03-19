using AutoMapper;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<EmployeeVM, EmployeeDto>().ReverseMap().ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate.ToString("yyyy-MM-dd")));

        }
    }
}
