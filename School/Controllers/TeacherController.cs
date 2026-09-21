using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.TeacherDTOs;
using School.Model;
using School.DTO;
using AutoMapper;
using School.Mapping;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
            private readonly AppContexts appContexts;
        private readonly IMapper mapper;

        public TeacherController()
            {
            appContexts = new AppContexts();
            mapper = new MapperConfiguration(g=>g.AddProfile<TeacherProfile>()).CreateMapper();

        }


            [HttpGet]
            public IActionResult GetAll()
            {
            //DTO
            //    var te = appContexts.Teachers.Include(u=>u.department).ToList();

            //List<TeacherDTO> result = new List<TeacherDTO>();
            //foreach (var teacher in te)
            //    {
            //        var det = new TeacherDTO
            //        {
            //            id = teacher.TeacherId,
            //            FullName = teacher.FirstName + " " + teacher.LastName, 

            //            DepartmentName = teacher.department.Name
            //        };
            //        result.Add(det);
            //    }
            //return Ok(result);


            var te = appContexts.Teachers.Include(u => u.department).ToList();

            List<TeacherDTO> result = mapper.Map<List<TeacherDTO>>(te);
            
            return Ok(result);
        }

        //[HttpGet("WithDepart")]

        //public IActionResult GetAllWithTeacher()
        //{
        //    var te = appContexts.Teachers.Include(j => j.department).ToList();
        //    var i = new TeacherDTO()
        //    {
        //        FullName = te.FirstName + " " + te.LastName,
        //        DepartmentName = te.department.Name
        //    };
        //    return Ok(i);
        //}

        [HttpGet("WithId")]
        public IActionResult GetId(int id)
        {
            var te = appContexts.Teachers.Include(j=>j.department)
                .FirstOrDefault(o => o.TeacherId == id);

            if (te == null)
            {
                return NotFound("Teacher not found");
            }

            var v = new TeacherDTO();

            v.id = te.TeacherId;
            v.FullName = te.FirstName + " " + te.LastName;
            v.DepartmentName = te.department.Name;

            return Ok(v);
        }

        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO t)
        {
            //if (t == null)
            //{
            //    return BadRequest("Not Created");
            //}


            //var dep=appContexts.Departments.FirstOrDefault(o => o.Name == t.DepartmentName);

            //var te = new Teacher()
            //{
            //    FirstName = t.FirstName,
            //    LastName = t.LastName,
            //    department = dep,
            //    Email = t.Email,
            //    Salary = t.Salary,
            //    Phone = t.Phone

            //};

            //var result = new TeacherDTO
            //{
            //    id = te.TeacherId,
            //    FullName = te.FirstName + " " + te.LastName,
            //    DepartmentName = te.department.Name
            //};

            //appContexts.Teachers.Add(te);
            //appContexts.SaveChanges();

            //return Ok(result);

            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var dep = appContexts.Departments.FirstOrDefault(o => o.Name == t.DepartmentName);


            var teacher = mapper.Map<Teacher>(t);
            teacher.department = dep; 
            appContexts.Teachers.Add(teacher);
            appContexts.SaveChanges();
            var teacherDTO = mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }

        [HttpPut]

        public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
        {
            if (t == null)
            {
                return NotFound();
            }
            var teacher = appContexts.Teachers
        .Include(x => x.department)
        .FirstOrDefault(x => x.TeacherId == id);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }
            teacher.department.Name = t.DepartmentName;
            teacher.FirstName = t.FirstName;
            teacher.LastName = t.LastName;
            



            appContexts.SaveChanges();
            return Ok(t);
        }


        [HttpPatch]
            public IActionResult PartUpdateTeacher(Teacher t, int id)
            {
                var dep = appContexts.Teachers.FirstOrDefault(o => o.TeacherId == id);
                if (t == null)
                {
                    return NotFound();
                }
            dep.FirstName = t.FirstName;
            dep.LastName = t.LastName;
            dep.Email = t.Email;
            dep.Phone = t.Phone;
            dep.Salary = t.Salary;
            appContexts.SaveChanges();
                return Ok(dep);
            }


            [HttpDelete]
            public IActionResult DeleteTeacher(int id)
            {
                var dep = appContexts.Teachers.FirstOrDefault(o => o.TeacherId == id);
                if (dep == null)
                {
                    return NotFound();
                }
                appContexts.Teachers.Remove(dep);
                appContexts.SaveChanges();
                return Ok(dep);
            }


        [HttpGet("Search")]
        public IActionResult SearchTeacher(string first, string last)
        {
            var dep = appContexts.Teachers.Where(a=>a.FirstName==first).Where(j=>j.LastName==last).ToList();
            if (dep == null)
            {
                return NotFound();
            }
            return Ok(dep);
        }

    }
    }



