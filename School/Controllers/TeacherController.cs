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

        //DTO
        //    private readonly AppContexts appContexts;

        //public TeacherController()
        //    {
        //    appContexts = new AppContexts();

        //}

        private readonly AppContexts appContexts;
        private readonly IMapper mapper;
        public TeacherController()
        {
            appContexts = new AppContexts();
            mapper = new MapperConfiguration(g => g.AddProfile<TeacherProfile>()).CreateMapper();

        }


        //DTO
        //  [HttpGet]
        //      public IActionResult GetAll()
        //      {
        //          var te = appContexts.Teachers.Include(u => u.department).ToList();

        //      List<TeacherDTO> result = new List<TeacherDTO>();
        //      foreach (var teacher in te)
        //      {
        //          var det = new TeacherDTO
        //          {
        //              id = teacher.TeacherId,
        //              FullName = teacher.FirstName + " " + teacher.LastName,

        //              DepartmentName = teacher.department.Name
        //          };
        //          result.Add(det);
        //      }
        //      return Ok(result);


        //}


        //Mapper
        [HttpGet]
        public IActionResult GetAll()
        {
            var te = appContexts.Teachers.Include(u => u.department).ToList();

            var result = mapper.Map<List<TeacherDTO>>(te);
            return Ok(result);


        }

        ////DTO
        //[HttpGet("WithId")]
        //public IActionResult GetId(int id)
        //{
        //    var te = appContexts.Teachers.Include(j=>j.department)
        //        .FirstOrDefault(o => o.TeacherId == id);

        //    if (te == null)
        //    {
        //        return NotFound("Teacher not found");
        //    }

        //    var v = new TeacherDTO()
        //    {
        //        id = te.departmentId,
        //        DepartmentName = te.department.Name,
        //        FullName = te.FirstName + " " + te.LastName
        //    };

        //    return Ok(v);
        //}

        //Mapper
        [HttpGet("WithId")]
        public IActionResult GetId(int id)
        {
            var te = appContexts.Teachers.Include(j => j.department)
                .FirstOrDefault(o => o.TeacherId == id);

            if (te == null)
            {
                return NotFound("Teacher not found");
            }

            var v = mapper.Map<TeacherDTO>(te);

            return Ok(v);
        }

        //DTO

        //[HttpPost]
        //public IActionResult CreateTeacher(CreateTeacherDTO t)
        //{
        //    if (t == null)
        //    {
        //        return BadRequest("Not Created");
        //    }


        //    var dep = appContexts.Departments.FirstOrDefault(o => o.Name == t.DepartmentName);

        //    var te = new Teacher()
        //    {
        //        department = dep,
        //        Email = t.Email,
        //        Salary = t.Salary,
        //        Phone = t.Phone,
        //        FirstName=t.FirstName,
        //        LastName=t.LastName


        //    };
        //    appContexts.Teachers.Add(te);
        //    appContexts.SaveChanges();

        //    var result = new TeacherDTO
        //    {
        //        FullName = te.FirstName + " " + te.LastName,
        //        DepartmentName = te.department.Name
        //    };


        //    return Ok(result);

        //}

        //mapper
        [HttpPost]
        public IActionResult CreateTeacher(CreateTeacherDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }


            var dep = appContexts.Departments.FirstOrDefault(o => o.Name == t.DepartmentName);
            if (dep == null)
            {
                return BadRequest();
            }
            var te = mapper.Map<Teacher>(t);
            te.department = dep;
            appContexts.Teachers.Add(te);
            appContexts.SaveChanges();

            var result = mapper.Map<TeacherDTO>(te);

            return Ok(result);

        }

        //DTO
        //[HttpPut]

        //public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
        //{
        //    var tea = appContexts.Teachers.Include(j => j.department).FirstOrDefault(j => j.TeacherId == id);
        //    if (t == null)
        //    {
        //        return BadRequest("not ");
        //    }

        //                if (tea == null)
        //    {
        //        return NotFound("not created");
        //    }

        //    var dep = appContexts.Departments.FirstOrDefault(h => h.Name == t.DepartmentName);
        //    if (dep == null)
        //    {
        //        return BadRequest("not ");
        //    }
        //    var name = t.FullName.Split(' ');
        //    tea.FirstName = name[0];
        //    tea.LastName = name[1];
        //    tea.department = dep;
        //    appContexts.SaveChanges();

        //    return Ok(t);
        //}

        //Mapper
        [HttpPut]

        public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
        {
            var tea = appContexts.Teachers.Include(j => j.department).FirstOrDefault(j => j.TeacherId == id);
            if (t == null)
            {
                return BadRequest("not ");
            }

            if (tea == null)
            {
                return NotFound("not created");
            }

            var dep = appContexts.Departments.FirstOrDefault(h => h.Name == t.DepartmentName);
            if (dep == null)
            {
                return BadRequest("not ");
            }
            mapper.Map(t, tea);
            tea.department = dep;
            appContexts.SaveChanges();
            var res = mapper.Map<TeacherDTO>(tea);
            return Ok(res);
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



