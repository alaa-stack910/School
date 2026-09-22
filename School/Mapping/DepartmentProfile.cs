using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using School.Model;
using School.DTO;
using School.DTO.StudentDTOs;
using School.DTO.DepartmentDTOs;


namespace School.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() {
            CreateMap<Department, DepartmentDTO>().ForMember(x => x.DepartmentName, y => y.MapFrom(n => n.Name));
            CreateMap<CreateDepartmentDTO, Department>().ForMember(x => x.Name, y => y.MapFrom(n => n.DepartmentName));
            CreateMap<UpdateDepartmentDTO, Department>().ForMember(x => x.Name, y => y.MapFrom(n => n.DepartmentName));
        } }
}
