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
        //DTO
        //    private readonly AppContexts appContexts;

        //public StudentController()
        //{
        //    appContexts = new AppContexts();

        //}


        //Mapper
        private readonly AppContexts appContexts;
        private readonly IMapper mapper;

        public StudentController()
        {
            appContexts = new AppContexts();
            mapper = new MapperConfiguration(g => g.AddProfile<StudentProfile>()).CreateMapper();

        }


        //DTO
        //[HttpGet]
        //    public IActionResult GetAll()
        //    {
        //        var te = appContexts.Students.Include(g=>g.ClassRoom).ToList();
        //    List<StudentDTO> result = new List<StudentDTO>();
        //    foreach (var student in te)
        //    {
        //        var stu = new StudentDTO
        //        {
        //            Id = student.Id,
        //            FullName = student.FirstName + " " + student.LastName,
        //            ClassRoomName = student.ClassRoom.Name,
        //            Email = student.Email,
        //            DateOfBirth = student.DateOfBirth,
        //            PhoneNumber = student.PhoneNumber
        //        };
        //        result.Add(stu);
        //    }
        //    return Ok(result);

        //    }


        //Mapper
        [HttpGet]
        public IActionResult GetAll()
        {
            var te = appContexts.Students.Include(g => g.ClassRoom).ToList();
            var res = mapper.Map<List<StudentDTO>>(te);
            return Ok(res);

        }

        //DTO
        //[HttpGet("WithId")]

        //    public IActionResult GetId(int id)
        //    {
        //        var te = appContexts.Students.Include(j => j.ClassRoom).FirstOrDefault(o => o.Id == id);

        //    var stu=new StudentDTO()
        //    {
        //        Id = te.Id,
        //        FullName = te.FirstName + " " + te.LastName,
        //        ClassRoomName = te.ClassRoom.Name,
        //        Email = te.Email,
        //        DateOfBirth = te.DateOfBirth,
        //        PhoneNumber = te.PhoneNumber
        //    };

        //    return Ok(te);

        //}


        [HttpGet("WithId")]

        public IActionResult GetId(int id)
        {
            var te = appContexts.Students.Include(j => j.ClassRoom).FirstOrDefault(o => o.Id == id);

            if (te == null)
            {
                return NotFound();
            }
            var res = mapper.Map<StudentDTO>(te);
            return Ok(te);

        }



        //DTO
        //[HttpPost]

        //public IActionResult CreateDepartment(CreateStudentDTO t)
        //{
        //    if (t == null)
        //    {
        //        return BadRequest("Not Created");
        //    }
        //    var clas = appContexts.ClassRooms.FirstOrDefault(o => o.Name == t.ClassRoomName);
        //    if (clas == null)
        //    {
        //        return BadRequest("Bad Request");
        //    }
        //    var s = new Student
        //    {
        //        FirstName=t.FirstName,
        //        LastName=t.LastName,
        //        Email=t.Email,
        //        PhoneNumber=t.PhoneNumber,
        //        DateOfBirth=t.DateOfBirth,
        //        ClassRoom=clas
        //    };
        //    appContexts.Students.Add(s);
        //    appContexts.SaveChanges();


        //    var res = new StudentDTO()
        //    {
        //        FullName = s.FirstName + " " + s.LastName,
        //        ClassRoomName = s.ClassRoom.Name,
        //        Email = s.Email,
        //        DateOfBirth = s.DateOfBirth,
        //        PhoneNumber = s.PhoneNumber

        //    };
        //    return Ok(res);
        //}

        //Mapper
        [HttpPost]

        public IActionResult CreateDepartment(CreateStudentDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var r = appContexts.ClassRooms.FirstOrDefault(g => g.Name == t.ClassRoomName);
            var s = mapper.Map<Student>(t);
            s.ClassRoom=r;
            appContexts.Students.Add(s);
            appContexts.SaveChanges();

            var res = mapper.Map<StudentDTO>(s);


            return Ok(res);
        }


        //DTO
        //[HttpPut]

        //    public IActionResult UpdateDepartment(UpdateStudentDTO t, int id)
        //    {
        //        var dep = appContexts.Students.FirstOrDefault(o => o.Id == id);
        //        if (t == null)
        //        {
        //            return NotFound();
        //        }
        //    var clas = appContexts.ClassRooms.FirstOrDefault(h => h.Name == t.ClassRoomName);

        //    var name = t.FullName.Split(' ');
        //    dep.FirstName = name[0];
        //    dep.LastName = name[1];
        //    dep.Email = t.Email;
        //    dep.DateOfBirth = t.DateOfBirth;
        //    dep.PhoneNumber = t.PhoneNumber;
        //    dep.ClassRoom = clas;
        //        appContexts.SaveChanges();
        //        return Ok(t);
        //    }

        //Mapper
        [HttpPut]

        public IActionResult UpdateDepartment(UpdateStudentDTO t, int id)
        {
            var dep = appContexts.Students.FirstOrDefault(o => o.Id == id);
            if (t == null)
            {
                return NotFound();
            }
            var r = appContexts.ClassRooms.FirstOrDefault(g => g.Name == t.ClassRoomName);

            mapper.Map(t, dep);
            dep.ClassRoom = r;
            appContexts.SaveChanges();
            var res = mapper.Map<StudentDTO>(dep);
            return Ok(res);
        }



        [HttpPatch]
            public IActionResult PartUpdateDepartment(StudentDTO t, int id)
            {
                var dep = appContexts.Students.FirstOrDefault(o => o.Id == id);
                if (t == null)
                {
                    return NotFound();
                }
            var name = t.FullName.Split(' ');
            dep.FirstName = name[0];
            dep.LastName = name[1];
            dep.Email = t.Email;
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




