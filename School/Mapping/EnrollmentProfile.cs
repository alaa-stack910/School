
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO;
using School.DTO.StudentDTOs;
using School.DTO.DepartmentDTOs;
using School.DTO.SubjectDTOs;
using School.DTO.ClassRoomDTOs;
using School.DTO.EnrollmentDTOs;
namespace School.Mapping
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>().ForMember(x => x.SubjectName, y => y.MapFrom(g => g.Subject.Name))
                .ForMember(x => x.StudentName, y => y.MapFrom(g => g.Student.FirstName + " " + g.Student.LastName));

            CreateMap<CreateEnrollmentDTO, Enrollment>();

            CreateMap<UpdateEnrollmentDTO, Enrollment>();

        }
    }
}
