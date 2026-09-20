using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.TeacherDTOs;
using School.Model;
using School.DTO;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
            private readonly AppContexts appContexts;

            public TeacherController()
            {
                appContexts = new AppContexts();
            }


            [HttpGet]
            public IActionResult GetAll()
            {
                var te = appContexts.Teachers.Include(u=>u.department).ToList();

            List<TeacherDTO> result = new List<TeacherDTO>();
            foreach (var teacher in te)
                {
                    var det = new TeacherDTO
                    {
                        id = teacher.TeacherId,
                        FullName = teacher.FirstName + " " + teacher.LastName, 

                        DepartmentName = teacher.department.Name
                    };
                    result.Add(det);
                }
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
            if (t == null)
            {
                return BadRequest("Not Created");
            }

            var te = new Teacher()
            {
                
                
            };
            appContexts.Teachers.Add(te);
            appContexts.SaveChanges();
            return Ok();
        }


        //[HttpPut]

        //public IActionResult UpdateTeacher(UpdateTeacherDTO t, int id)
        //{
        //    var dep = appContexts.Teachers.FirstOrDefault(o => o.TeacherId == id);
        //    if (t == null)
        //    {
        //        return NotFound();
        //    }
        //var v = new Teacher()
        //{
        //    FirstName = t.Firstname,
        //    LastName = t.Lastname

        //};


        ////    dep.FirstName = t.FirstName;
        ////    dep.LastName = t.LastName;
        ////dep.Email = t.Email;
        ////dep.Phone = t.Phone;
        ////dep.Salary = t.Salary;
        //    appContexts.SaveChanges();
        //    return Ok(t);
        //}


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



