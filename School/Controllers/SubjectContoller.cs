//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
//using School;
//using School.DTO.ClassRoomDTOs;
//using School.DTO.DepartmentDTOs;
//using School.DTO.SubjectDTOs;
//using School.Mapping;
//using School.Model;

//namespace School.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SubjectContoller : ControllerBase
//    {


//        //DTO
//        //    private readonly AppContexts appContexts;

//        //public TeacherController()
//        //    {
//        //    appContexts = new AppContexts();

//        //}

//        private readonly AppContexts appContexts;
//        private readonly IMapper mapper;
//        public SubjectContoller(AppContexts appContexts)
//        {
//            this.appContexts = appContexts;

//        mapper = new MapperConfiguration(g => g.AddProfile<SubjectProfile>()).CreateMapper();

//        }


//        ////DTP
//        //[HttpGet]
//        //    public IActionResult GetAll()
//        //    {
//        //        var te = appContexts.Subjects.Include(s => s.Teacher).ToList();
//        //        List<SubjectDTO> result = new List<SubjectDTO>();

//        //        foreach (var subject in te)
//        //        {
//        //        var s = new SubjectDTO
//        //        {
//        //            Id = subject.Id,
//        //            Name = subject.Name,
//        //            Description = subject.Description,
//        //            MaxGrade = subject.MaxGrade,
//        //            TeacherName = subject.Teacher.FirstName + " " + subject.Teacher.LastName

//        //        };
//        //            result.Add(s);
//        //        }
//        //        return Ok(result);

//        //    }

//        //mapper
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var te = appContexts.Subjects.Include(s => s.Teacher).ToList();
//            var result = mapper.Map<List<SubjectDTO>>(te);
//            return Ok(result);

//        }


//        //DTO
//        //[HttpGet("WithId")]

//        //    public IActionResult GetId(int id)
//        //    {
//        //        var te = appContexts.Subjects.Include(i=>i.Teacher).FirstOrDefault(o => o.Id == id);
//        //        var clas = new SubjectDTO
//        //        {
//        //            Id = te.Id,
//        //            Name = te.Name,
//        //            MaxGrade = te.MaxGrade,
//        //            Description = te.Description,
//        //            TeacherName = te.Teacher.FirstName + " " + te.Teacher.LastName
//        //        };

//        //        return Ok(clas);
//        //    }

//        //mapper

//        [HttpGet("WithId")]

//        public IActionResult GetId(int id)
//        {
//            var te = appContexts.Subjects.Include(s => s.Teacher).FirstOrDefault(k => k.Id == id);

//            if (te == null)
//            {
//                return NotFound();
//            }
//            var result = mapper.Map<SubjectDTO>(te);

//            return Ok(result);
//        }

//        //DTO

//        //[HttpPost]

//        //    public IActionResult CreateSubject(CreateSubjectDTO t)
//        //    {
//        //        if (t == null)
//        //        {
//        //            return NotFound("Not Created");
//        //        }
//        //        var te = appContexts.Teachers.FirstOrDefault(o => o.FirstName+" "+o.LastName==t.TeacherName );

//        //    if (te == null)
//        //    {
//        //        return NotFound("Not Created");
//        //    }

//        //    var clas = new Subject
//        //    {
//        //        Name = t.Name,
//        //        MaxGrade = t.MaxGrade,
//        //        Description = t.Description,
//        //        Teacher = te
//        //    };
//        //        appContexts.Subjects.Add(clas);
//        //        appContexts.SaveChanges();
//        //        return Ok(t);
//        //    }

//        //mapper
//        [HttpPost]
//        public IActionResult CreateSubject(CreateSubjectDTO t)
//        {
//            if (t == null)
//            {
//                return BadRequest("Not Created");
//            }
//            var te = appContexts.Teachers.FirstOrDefault(g => g.FirstName + " " + g.LastName == t.TeacherName);
//            var sub = mapper.Map<Subject>(t);
//            sub.Teacher = te;
//            appContexts.Subjects.Add(sub);
//            appContexts.SaveChanges();

//            var res = mapper.Map<SubjectDTO>(sub);

//            return Ok(res);
//        }


//        //DTO
//        //[HttpPut]

//        //    public IActionResult UpdateSubjects(UpdateSubjectDTO t, int id)
//        //    {
//        //        var dep = appContexts.Subjects.FirstOrDefault(o => o.Id == id);
//        //    if (t == null)
//        //    {
//        //        return NotFound("Not Created");
//        //    }
//        //    var te = appContexts.Teachers.FirstOrDefault(o => o.FirstName + " " + o.LastName == t.TeacherName);

//        //    if (te == null)
//        //    {
//        //        return NotFound("Not Created");
//        //    }
//        //    dep.Name = t.Name;
//        //    dep.Description = t.Description;
//        //    dep.MaxGrade = t.MaxGrade;
//        //    dep.Teacher = te;


//        //    appContexts.SaveChanges();
//        //        return Ok(t);
//        //    }


//        //Mapper
//        [HttpPut]

//        public IActionResult UpdateSubject(UpdateSubjectDTO t, int id)
//        {
//            var dep = appContexts.Subjects.Include(h=>h.Teacher).FirstOrDefault(o => o.Id == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            var te = appContexts.Teachers.FirstOrDefault(g => g.FirstName + " " + g.LastName == t.TeacherName);

//            mapper.Map(t, dep);
//            dep.Teacher = te;

//            appContexts.SaveChanges();
//            var res = mapper.Map<SubjectDTO>(dep);

//            return Ok(res);
//        }


//        [HttpPatch]
//        public IActionResult PartUpdateDepartment(Subject t, int id)
//        {
//            var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            dep.Name = t.Name;
//            dep.Description = t.Description;
//            appContexts.SaveChanges();
//            return Ok(dep);
//        }


//        [HttpDelete]
//            public IActionResult DeleteSubject(int id)
//            {
//                var dep = appContexts.Subjects.FirstOrDefault(o => o.Id == id);
//                if (dep == null)
//                {
//                    return NotFound();
//                }
//                appContexts.Subjects.Remove(dep);
//                appContexts.SaveChanges();
//                return Ok(dep);
//            }
//        }
//    }

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using School;
using School.DTO.ClassRoomDTOs;
using School.DTO.DepartmentDTOs;
using School.DTO.SubjectDTOs;
using School.Mapping;
using School.Model;
using School.Repo.Interface;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectContoller : ControllerBase
    {


        private readonly IGenericRepo<Student> repo;

        private readonly IMapper mapper;



        public SubjectContoller(IGenericRepo<Student> repos)
        {
            repo = repos;
            mapper = new MapperConfiguration(g => g.AddProfile<SubjectProfile>()).CreateMapper();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var te = repo.GetAll();
            var result = mapper.Map<List<SubjectDTO>>(te);
            return Ok(result);

        }


       

        [HttpGet("WithId")]

        public IActionResult GetId(int id)
        {
            var te = repo.GetById( id);

            if (te == null)
            {
                return NotFound();
            }
            var result = mapper.Map<SubjectDTO>(te);

            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var te = appContexts.Teachers.FirstOrDefault(g => g.FirstName + " " + g.LastName == t.TeacherName);
            var sub = mapper.Map<Subject>(t);
            sub.Teacher = te;
            appContexts.Subjects.Add(sub);
            appContexts.SaveChanges();

            var res = mapper.Map<SubjectDTO>(sub);

            return Ok(res);
        }


        //DTO
        //[HttpPut]

        //    public IActionResult UpdateSubjects(UpdateSubjectDTO t, int id)
        //    {
        //        var dep = appContexts.Subjects.FirstOrDefault(o => o.Id == id);
        //    if (t == null)
        //    {
        //        return NotFound("Not Created");
        //    }
        //    var te = appContexts.Teachers.FirstOrDefault(o => o.FirstName + " " + o.LastName == t.TeacherName);

        //    if (te == null)
        //    {
        //        return NotFound("Not Created");
        //    }
        //    dep.Name = t.Name;
        //    dep.Description = t.Description;
        //    dep.MaxGrade = t.MaxGrade;
        //    dep.Teacher = te;


        //    appContexts.SaveChanges();
        //        return Ok(t);
        //    }


        //Mapper
        [HttpPut]

        public IActionResult UpdateSubject(UpdateSubjectDTO t, int id)
        {
            var dep = appContexts.Subjects.Include(h => h.Teacher).FirstOrDefault(o => o.Id == id);
            if (t == null)
            {
                return NotFound();
            }
            var te = appContexts.Teachers.FirstOrDefault(g => g.FirstName + " " + g.LastName == t.TeacherName);

            mapper.Map(t, dep);
            dep.Teacher = te;

            appContexts.SaveChanges();
            var res = mapper.Map<SubjectDTO>(dep);

            return Ok(res);
        }


        [HttpPatch]
        public IActionResult PartUpdateDepartment(Subject t, int id)
        {
            var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
            if (t == null)
            {
                return NotFound();
            }
            dep.Name = t.Name;
            dep.Description = t.Description;
            appContexts.SaveChanges();
            return Ok(dep);
        }


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
