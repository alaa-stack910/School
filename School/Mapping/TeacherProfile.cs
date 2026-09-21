using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO.TeacherDTOs;
namespace School.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher,TeacherDTO>().ForMember(dest => dest.id,
        opt => opt.MapFrom(src => src.TeacherId))
    .ForMember(dest => dest.FullName,
        opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
    .ForMember(dest => dest.DepartmentName,
        opt => opt.MapFrom(src => src.department.Name));


            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher,UpdateTeacherDTO>().ReverseMap();
        }
    }
}
