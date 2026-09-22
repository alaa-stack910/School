
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO;
using School.DTO.StudentDTOs;

namespace School.Mapping
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ForMember(x=>x.FullName,y=>y.MapFrom(h=>h.FirstName+" "+ h.LastName)).ForMember
                (x=>x.ClassRoomName,t=>t.MapFrom(g=>g.ClassRoom.Name));

            CreateMap<CreateStudentDTO, Student>();

            CreateMap<UpdateStudentDTO, Student>().AfterMap((s, d) =>
            {
                var name = s.FullName.Split(' ');
                d.FirstName = name[0];
                d.LastName = name[1];
            });
        }

    }
}
//{
//    "firstName": "Moaz",
//  "lastName": "Ahmed",
//  "email": "ss@gmail.com",
//  "phoneNumber": "1234567890",
//  "dateOfBirth": "2026-09-12",
//  "classRoomName": "S3"
//}