//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School.DTO.TeacherDTOs;
//using School.Model;
//using School.DTO;
//using AutoMapper;
//using School.Mapping;
//using School.Repo.Interface;

//namespace School.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeacherController : ControllerBase
//    {

//        //DTO
//        //    private readonly AppContexts appContexts;

//        //public TeacherController()
//        //    {
//        //    appContexts = new AppContexts();

//        //}

//        private readonly IMapper mapper;
//        private readonly ITeacher iteacher;

//        public TeacherController(ITeacher iteachers)
//        {
//            it
//            mapper = new MapperConfiguration(g => g.AddProfile<DepartmentProfile>()).CreateMapper();

//        }



//[HttpGet]
//public IActionResult GetAll()
//{
//    var te = appContexts.Teachers.Include(u => u.department).ToList();

//    var result = mapper.Map<List<TeacherDTO>>(te);
//    return Ok(result);


//}

//        [HttpGet("WithId")]
//        public IActionResult GetId(int id)
//        {
//            var te = appContexts.Teachers.Include(j => j.department)
//                .FirstOrDefault(o => o.TeacherId == id);

//            if (te == null)
//            {
//                return NotFound("Teacher not found");
//            }

//            var v = mapper.Map<TeacherDTO>(te);

//            return Ok(v);
//        }

//        [HttpPost]
//        public IActionResult CreateTeacher(CreateTeacherDTO t)
//        {
//            if (t == null)
//            {
//                return BadRequest("Not Created");
//            }


//            var dep = appContexts.Departments.FirstOrDefault(o => o.Name == t.DepartmentName);
//            if (dep == null)
//            {
//                return BadRequest();
//            }
//            var te = mapper.Map<Teacher>(t);
//            te.department = dep;
//            appContexts.Teachers.Add(te);
//            appContexts.SaveChanges();

//            var result = mapper.Map<TeacherDTO>(te);

//            return Ok(result);

//        }

//        //DTO
//        //[HttpPut]

//        //public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
//        //{
//        //    var tea = appContexts.Teachers.Include(j => j.department).FirstOrDefault(j => j.TeacherId == id);
//        //    if (t == null)
//        //    {
//        //        return BadRequest("not ");
//        //    }

//        //                if (tea == null)
//        //    {
//        //        return NotFound("not created");
//        //    }

//        //    var dep = appContexts.Departments.FirstOrDefault(h => h.Name == t.DepartmentName);
//        //    if (dep == null)
//        //    {
//        //        return BadRequest("not ");
//        //    }
//        //    var name = t.FullName.Split(' ');
//        //    tea.FirstName = name[0];
//        //    tea.LastName = name[1];
//        //    tea.department = dep;
//        //    appContexts.SaveChanges();

//        //    return Ok(t);
//        //}

//        //Mapper
//        [HttpPut]

//        public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
//        {
//            var tea = appContexts.Teachers.Include(j => j.department).FirstOrDefault(j => j.TeacherId == id);
//            if (t == null)
//            {
//                return BadRequest("not ");
//            }

//            if (tea == null)
//            {
//                return NotFound("not created");
//            }

//            var dep = appContexts.Departments.FirstOrDefault(h => h.Name == t.DepartmentName);
//            if (dep == null)
//            {
//                return BadRequest("not ");
//            }
//            mapper.Map(t, tea);
//            tea.department = dep;
//            appContexts.SaveChanges();
//            var res = mapper.Map<TeacherDTO>(tea);
//            return Ok(res);
//        }



//        [HttpPatch]
//            public IActionResult PartUpdateTeacher(Teacher t, int id)
//            {
//                var dep = appContexts.Teachers.FirstOrDefault(o => o.TeacherId == id);
//                if (t == null)
//                {
//                    return NotFound();
//                }
//            dep.FirstName = t.FirstName;
//            dep.LastName = t.LastName;
//            dep.Email = t.Email;
//            dep.Phone = t.Phone;
//            dep.Salary = t.Salary;
//            appContexts.SaveChanges();
//                return Ok(dep);
//            }


//            [HttpDelete]
//            public IActionResult DeleteTeacher(int id)
//            {
//                var dep = appContexts.Teachers.FirstOrDefault(o => o.TeacherId == id);
//                if (dep == null)
//                {
//                    //return NotFound();
//                }
//                appContexts.Teachers.Remove(dep);
//                appContexts.SaveChanges();
//                return Ok(dep);
//            }


//        [HttpGet("Search")]
//        public IActionResult SearchTeacher(string first, string last)
//        {
//            var dep = iterator.Teachers.Where(a=>a.FirstName==first).Where(j=>j.LastName==last).ToList();
//            if (dep == null)
//            {
//                return NotFound();
//            }
//            return Ok(dep);
//        }

//    }
//    }



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.TeacherDTOs;
using School.Model;
using School.DTO;
using AutoMapper;
using School.Mapping;
using School.Repo.Interface;
using System;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        //DTO
        //    private readonly AppContexts appContexts;

        //public TeacherController()
        //    {
        //    appContexts = new AppContexts();

        //}

        private readonly IMapper mapper;
        private readonly ITeacher iteacher;

        public TeacherController(ITeacher iteachers)
        {
            iteacher = iteachers;
            mapper = new MapperConfiguration(g => g.AddProfile<TeacherProfile>()).CreateMapper();

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var te = iteacher.GetAll();

            var result = mapper.Map<List<TeacherDTO>>(te);
            return Ok(result);


        }


        [HttpGet("Filter")]
        public IActionResult Filter(int salaey, int id)
        {
            var teachers = iteacher.FilterOnSalary(salaey, id);
            var teacherDTOs = mapper.Map<List<TeacherDTO>>(teachers);
            return Ok(teacherDTOs);

        }
        [HttpGet("GetByEmail")]
        public IActionResult GetBYEmail(string email)
        {
            var teacher = iteacher.GetEmail(email);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDTO = mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }
        [HttpGet("CheckSubjectTaught")]

        public bool CheckSubjectTaught(int id)
        {
            var t = iteacher.CheckSubjectTaught(id);

            return t;
        }



    }
}
