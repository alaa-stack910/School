//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School.DTO.DepartmentDTOs;
//using School.DTO.StudentDTOs;
//using School.Mapping;
//using School.Model;

//namespace School.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        //DTO
//        //    private readonly AppContexts appContexts;

//        //public StudentController()
//        //{
//        //    appContexts = new AppContexts();

//        //}


//        //Mapper
//        private readonly AppContexts appContexts;
//        private readonly IMapper mapper;

//        public StudentController(AppContexts appContexts)
//        {
//            this.appContexts = appContexts;
//            mapper = new MapperConfiguration(g => g.AddProfile<StudentProfile>()).CreateMapper();

//        }


//        //DTO
//        //[HttpGet]
//        //    public IActionResult GetAll()
//        //    {
//        //        var te = appContexts.Students.Include(g=>g.ClassRoom).ToList();
//        //    List<StudentDTO> result = new List<StudentDTO>();
//        //    foreach (var student in te)
//        //    {
//        //        var stu = new StudentDTO
//        //        {
//        //            Id = student.Id,
//        //            FullName = student.FirstName + " " + student.LastName,
//        //            ClassRoomName = student.ClassRoom.Name,
//        //            Email = student.Email,
//        //            DateOfBirth = student.DateOfBirth,
//        //            PhoneNumber = student.PhoneNumber
//        //        };
//        //        result.Add(stu);
//        //    }
//        //    return Ok(result);

//        //    }


//        //Mapper
//        //[HttpGet]
//        //public IActionResult GetAll()
//        //{
//        //    var te = appContexts.Students.Include(g => g.ClassRoom).ToList();
//        //    var res = mapper.Map<List<StudentDTO>>(te);
//        //    return Ok(res);

//        //}

//        //LINQ
//        //[HttpGet]
//        //public IActionResult GetAll()
//        //{
//        //    var te = appContexts.Students.Include(g => g.ClassRoom).OrderByDescending(n => n.LastName).ToList();
//        //    var res = mapper.Map<List<StudentDTO>>(te);
//        //    return Ok(res);

//        //}

//        ////LINQ
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var te = appContexts.Students.ToList();
//            return Ok(te);

//        }

//        //LINQ1
//        //[HttpGet("Grade")]
//        //public IActionResult GetAll(int id, int grade)
//        //{
//        //    var te = appContexts.Students.Where(g=>g.ClassRoomId==id&& g.Enrollments.Any(v=>v.Grade>=grade)).Select( a=> new
//        //    {
//        //        Id= a.Id,
//        //        FullName = a.FirstName + " " + a.LastName

//Mapper
//[HttpGet]
//public IActionResult GetAll()
//{
//    var te = appContexts.Students.Include(g => g.ClassRoom).ToList();
//    var res = mapper.Map<List<StudentDTO>>(te);
//    return Ok(res);

//        //}
//        //2
//        [HttpGet("Grade")]
//        public IActionResult GetAll(int id)
//        {
//            var te = appContexts.Students.Where(g => g.ClassRoomId == id ).OrderBy(h=>h.Id)
//                .Select(a => new
//            {
//                Id = a.Id,
//                FullName = a.FirstName + " " + a.LastName,
//                classname=a.ClassRoom.Name

//LINQ
//[HttpGet]
//public IActionResult GetAll()
//{
//    var te = appContexts.Students.Include(g => g.ClassRoom).OrderByDescending(n => n.LastName).ToList();
//    var res = mapper.Map<List<StudentDTO>>(te);
//    return Ok(res);

//        }

////LINQ
//using Microsoft.AspNetCore.Mvc;
//using School.Model;
//using School.Repo.Interface;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var te = appContexts.Students.ToList();
//            return Ok(te);

//        }

//LINQ1
//[HttpGet("Grade")]
//public IActionResult GetAll(int id, int grade)
//{
//    var te = appContexts.Students.Where(g=>g.ClassRoomId==id&& g.Enrollments.Any(v=>v.Grade>=grade)).Select( a=> new
//    {
//        Id= a.Id,
//        FullName = a.FirstName + " " + a.LastName

//        //    public IActionResult GetId(int id)
//        //    {
//        //        var te = appContexts.Students.Include(j => j.ClassRoom).FirstOrDefault(o => o.Id == id);

//}
//2
//[HttpGet("Grade")]
//public IActionResult GetAll(int id)
//{
//    var te = appContexts.Students.Where(g => g.ClassRoomId == id).OrderBy(h => h.Id)
//        .Select(a => new
//        {
//            a.Id,
//            FullName = a.FirstName + " " + a.LastName,
//            classname = a.ClassRoom.Name

//        });
//    return Ok(te);

//}

//        public IActionResult UpdateDepartment(UpdateStudentDTO t, int id)
//        {
//            var dep = appContexts.Students.FirstOrDefault(o => o.Id == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            var r = appContexts.ClassRooms.FirstOrDefault(g => g.Name == t.ClassRoomName);

//            mapper.Map(t, dep);
//            dep.ClassRoom = r;
//            appContexts.SaveChanges();
//            var res = mapper.Map<StudentDTO>(dep);
//            return Ok(res);
//        }



//        [HttpPatch]
//            public IActionResult PartUpdateDepartment(StudentDTO t, int id)
//            {
//                var dep = appContexts.Students.FirstOrDefault(o => o.Id == id);
//                if (t == null)
//                {
//                    return NotFound();
//                }
//            var name = t.FullName.Split(' ');
//            dep.FirstName = name[0];
//            dep.LastName = name[1];
//            dep.Email = t.Email;
//            appContexts.SaveChanges();
//                return Ok(dep);
//            }


//            [HttpDelete]
//            public IActionResult DeleteDepartment(int id)
//            {
//                var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
//                if (dep == null)
//                {
//                    return NotFound();
//                }
//                appContexts.Departments.Remove(dep);
//                appContexts.SaveChanges();
//                return Ok(dep);
//            }


//        }
//    }
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.DTO.StudentDTOs;
using School.Model;
using School.Repo.Interface;
using School.Mapping;
using School.Repo.Implement;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly Istudent istudent;

        public StudentController(Istudent student)
        {
            istudent = student;
            mapper = new MapperConfiguration(g => g.AddProfile<DepartmentProfile>()).CreateMapper();

        }

        [HttpGet]
        public IActionResult GetAll(int id)
        {

            var students = istudent.GetAll();

           
            return Ok(students);
        }


        //// GET: api/Student/Grade?id=1
        //[HttpGet("Grade")]
        //public IActionResult GetByClassRoomId(int id)
        //{
        //    var students = repository.GetByClassRoomId(id);

        //    var result = students.Select(s => new
        //    {
        //        Id = s.Id,
        //        FullName = s.FirstName + " " + s.LastName,
        //        ClassRoomName = s.ClassRoom?.Name
        //    }).ToList();

        //    return Ok(result);
        //}


        [HttpGet("WithId")]
        public IActionResult GetId(int id)
        {
            var student = istudent.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

          

            return Ok(student);
        }


        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }


            var student = new Student
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                Email = t.Email,
                PhoneNumber = t.PhoneNumber,
                DateOfBirth = t.DateOfBirth
                , ClassRoomId=t.ClassId

            };


            istudent.Add(student);

            var result = new StudentDTO
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                DateOfBirth = student.DateOfBirth

            };

            return Ok(result);
        }


        [HttpPut]
        public IActionResult UpdateStudent(
            UpdateStudentDTO t,
            int id)
        {
            if (t == null)
            {
                return BadRequest();
            }

            var student = istudent.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            var name = t.FullName.Split(' ');


            student.FirstName = name[0];
            student.LastName = name[1];
            student.Email = t.Email;
            student.PhoneNumber = t.PhoneNumber;
            student.DateOfBirth = t.DateOfBirth;

            istudent.Update(student);

            var result = new StudentDTO
            {
                Id = student.Id,
                FullName = student.FirstName + " " + student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                DateOfBirth = student.DateOfBirth,
                ClassId=student.ClassRoomId
              
            };

            return Ok(result);
        }


        //[HttpPatch]
        //public IActionResult PartUpdateStudent(
        //    StudentDTO t,
        //    int id)
        //{
        //    var student = repository.GetById(id);

        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    if (t == null)
        //    {
        //        return BadRequest();
        //    }

        //    var name = t.FullName.Split(
        //        ' ',
        //        StringSplitOptions.RemoveEmptyEntries);

        //    if (name.Length < 2)
        //    {
        //        return BadRequest(
        //            "Please enter first name and last name");
        //    }

        //    student.FirstName = name[0];
        //    student.LastName = name[1];
        //    student.Email = t.Email;

        //    repository.Update(student);

        //    return Ok(student);
        //}


        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var v= istudent.GetById(id);
            if (v == null)
            {
                return NotFound();
            }
            istudent.Delete(v);

            return NoContent();
        }
    }
}


