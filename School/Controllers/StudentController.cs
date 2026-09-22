using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.DepartmentDTOs;
using School.DTO.StudentDTOs;
using School.Mapping;
using School.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       
            private readonly AppContexts appContexts;
        private readonly IMapper mapper;

        public StudentController()
        {
            appContexts = new AppContexts();
            mapper = new MapperConfiguration(g => g.AddProfile<StudentProfile>()).CreateMapper();

        }


        [HttpGet]
            public IActionResult GetAll()
            {
                var te = appContexts.Students.ToList();
            //List<StudentDTO> result = new List<StudentDTO>();
            //foreach (var student in te)
            //{
            //    var stu = new StudentDTO
            //    {
            //        Id = student.Id,
            //        FullName = student.FirstName+" "+student.LastName,
            //        ClassRoomName = student.ClassRoom.Name,
            //        Email = student.Email,
            //        DateOfBirth = student.DateOfBirth,
            //        PhoneNumber = student.PhoneNumber
            //    };
            //    result.Add(stu);
            //}
            List<StudentDTO> result = mapper.Map<List<StudentDTO>>(te);
            return Ok(result);

            }

            //[HttpGet("WithTeacher")]

            //public IActionResult GetAllWithTeacher()
            //{
            //    var te = appContexts.Departments.Include(j => j.Teachers).ToList();
            //    return Ok(te);
            //}

            [HttpGet("WithId")]

            public IActionResult GetId(int id)
            {
                var te = appContexts.Students.Include(j => j.ClassRoom).FirstOrDefault(o => o.Id == id);
                var ve= mapper.Map<StudentDTO>(te);

            return Ok(te);
            }

            [HttpPost]

        public IActionResult CreateDepartment(CreateStudentDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            //var clas = appContexts.ClassRooms.FirstOrDefault(o => o.Name == t.ClassRoomName);
            //var s = new Student
            //{
            //};
            var te= mapper.Map<Student>(t);
            appContexts.Students.Add(te);
            appContexts.SaveChanges();
            var studentDTO = mapper.Map<StudentDTO>(te);
            return Ok(te);
        }


        [HttpPut]

            public IActionResult UpdateDepartment(UpdateDepartmentDTO t, int id)
            {
                var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
                if (t == null)
                {
                    return NotFound();
                }
                var department = new Department
                {
                    Name = t.DepartmentName,
                    Description = t.Description
                };
                appContexts.SaveChanges();
                return Ok(t);
            }


            [HttpPatch]
            public IActionResult PartUpdateDepartment(Department t, int id)
            {
                var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
                if (t == null)
                {
                    return NotFound();
                }
                mapper.Map(t, dep);
            appContexts.SaveChanges();
                return Ok(dep);
            }


            [HttpDelete]
            public IActionResult DeleteDepartment(int id)
            {
                var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
                if (dep == null)
                {
                    return NotFound();
                }
                appContexts.Departments.Remove(dep);
                appContexts.SaveChanges();
                return Ok(dep);
            }


        }
    }




