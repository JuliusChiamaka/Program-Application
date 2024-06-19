using AutoMapper;
using ProgramApplication.DTOs;
using ProgramApplication.Models;

namespace ProgramApplication.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Program, ProgrammeDto>().ReverseMap();
            CreateMap<ApplicationForm, ApplicationFormDto>().ReverseMap();
            CreateMap<CustomQuestion, CustomQuestionDto>().ReverseMap();
        }
    }
}
