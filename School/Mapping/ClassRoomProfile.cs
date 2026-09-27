

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO;
using School.DTO.StudentDTOs;
using School.DTO.DepartmentDTOs;
using School.DTO.SubjectDTOs;
using School.DTO.ClassRoomDTOs;


namespace School.Mapping
{
    public class ClassRoomProfile:Profile
    {
        public ClassRoomProfile()
        {
            CreateMap<ClassRoom, ClassRoomDTO>().ReverseMap();
            CreateMap<CreateClassRoom, ClassRoom>().ReverseMap();
            CreateMap<UpdateClassRoom, ClassRoom>().ReverseMap();
        }
    }
}
