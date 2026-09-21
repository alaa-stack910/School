using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DTO.ClassRoomDTOs;
using School.DTO.SubjectDTOs;
using School.Model;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectContoller : ControllerBase
    {
        

            private readonly AppContexts appContexts;

            public SubjectContoller()
            {
                appContexts = new AppContexts();
            }


            [HttpGet]
            public IActionResult GetAll()
            {
                var te = appContexts.Subjects.Include(s => s.Teacher).ToList();
                List<SubjectDTO> result = new List<SubjectDTO>();

                foreach (var subject in te)
                {
                var s = new SubjectDTO
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                    MaxGrade = subject.MaxGrade,
                    TeacherName = subject.Teacher.FirstName + " " + subject.Teacher.LastName

                };
                    result.Add(s);
                }
                return Ok(result);

            }

            //[HttpGet("WithTeacher")]

            //public IActionResult GetAllWithTeacher()
            //{
            //    var te = appContexts.ClassRooms.ToList();
            //    return Ok(te);
            //}

            [HttpGet("WithId")]

            public IActionResult GetId(int id)
            {
                var te = appContexts.Subjects.Include(i=>i.Teacher).FirstOrDefault(o => o.Id == id);
                var clas = new SubjectDTO
                {
                    Id = te.Id,
                    Name = te.Name,
                    MaxGrade = te.MaxGrade,
                    Description = te.Description,
                    TeacherName = te.Teacher.FirstName + " " + te.Teacher.LastName
                };

                return Ok(clas);
            }

            [HttpPost]

            public IActionResult CreateSubject(CreateSubjectDTO t)
            {
                if (t == null)
                {
                    return BadRequest("Not Created");
                }
                var te = appContexts.Teachers.FirstOrDefault(o => o.FirstName+" "+o.LastName==t.Name );
            var clas = new Subject
            {
                Name = t.Name,
                MaxGrade = t.MaxGrade,
                Description = t.Description,
                Teacher = te
            };
                appContexts.Subjects.Add(clas);
                appContexts.SaveChanges();
                return Ok(t);
            }


            [HttpPut]

            public IActionResult UpdateSubjects(UpdateSubjectDTO t, int id)
            {
                var dep = appContexts.Subjects.FirstOrDefault(o => o.Id == id);
                if (t == null)
                {
                    return NotFound();
                }
                dep.Name = t.Name;
                dep.Description = t.Description;
                dep.MaxGrade = t.MaxGrade;
            dep.Teacher.FirstName = t.Name;

            appContexts.SaveChanges();
                return Ok(t);
            }


            //[HttpPatch]
            //public IActionResult PartUpdateDepartment( t, int id)
            //{
            //    var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
            //    if (t == null)
            //    {
            //        return NotFound();
            //    }
            //    dep.Name = t.Name;
            //    dep.Description = t.Description;
            //    appContexts.SaveChanges();
            //    return Ok(dep);
            //}


            [HttpDelete]
            public IActionResult DeleteSubject(int id)
            {
                var dep = appContexts.Subjects.FirstOrDefault(o => o.Id == id);
                if (dep == null)
                {
                    return NotFound();
                }
                appContexts.Subjects.Remove(dep);
                appContexts.SaveChanges();
                return Ok(dep);
            }
        }
    }

