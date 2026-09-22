
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO;
using School.DTO.StudentDTOs;
using School.DTO.DepartmentDTOs;
using School.DTO.SubjectDTOs;


namespace School.Mapping
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDTO>().ForMember(x=>x.TeacherName,y=>y.MapFrom(g=>g.Teacher.FirstName+" "+g.Teacher.LastName));
            CreateMap<CreateSubjectDTO, Subject>();
            CreateMap<UpdateSubjectDTO, Subject>();
        }
    }
}
