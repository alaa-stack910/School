using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DTO.EnrollmentDTOs;
using School.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using School.Mapping;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        //DTO
        //private readonly AppContexts context;

        //public EnrollmentController()
        //{
        //    context = new AppContexts();
        //}

        //mapper
        private readonly AppContexts context;
        private readonly IMapper mapper;

        public EnrollmentController(AppContexts context )
        {
            context = new AppContexts();
        }



        //DTO
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var all = context.Enrollments.Include(i => i.Student).Include(h => h.Subject).ToList();
        //    List<EnrollmentDTO> dto = new List<EnrollmentDTO>();
        //    foreach (var e in all)
        //    {
        //        var dtoe = new EnrollmentDTO()
        //        {
        //            Id = e.Id,
        //            StudentName = e.Student.FirstName + " " + e.Student.LastName,
        //            Grade = e.Grade,
        //            EnrollmentDate = e.EnrollmentDate,
        //            SubjectName = e.Subject.Name
        //        };
        //        dto.Add(dtoe);
        //    }
        //    return Ok(dto);
        //}


        //Mapper
        [HttpGet]
        public IActionResult GetAll()
        {
            var all = context.Enrollments.Include(i => i.Student).Include(h => h.Subject).ToList();
            var res = mapper.Map<List<EnrollmentDTO>>(all);
            return Ok(res);
        }

        //DTO
        //[HttpGet("ID")]
        //public IActionResult GetID(int id)
        //{
        //    var enroll = context.Enrollments.Include(i => i.Student).Include(h => h.Subject).FirstOrDefault(u=>u.Id==id);
        //    var dtoe = new EnrollmentDTO()
        //    {
        //        Id = enroll.Id,
        //            StudentName = enroll.Student.FirstName + " " + enroll.Student.LastName,
        //        Grade = enroll.Grade,
        //        EnrollmentDate = enroll.EnrollmentDate,
        //        SubjectName = enroll.Subject.Name
        //    };
        //    return Ok(dtoe);
        //}


        //Mapper
        [HttpGet("ID")]
        public IActionResult GetID(int id)
        {
            var enroll = context.Enrollments.Include(i => i.Student).Include(h => h.Subject).FirstOrDefault(u => u.Id == id);
            var res = mapper.Map<EnrollmentDTO>(enroll);

            return Ok(res);
        }


        //DTO
        //[HttpPost]
        //public IActionResult Create(CreateEnrollmentDTO dto)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest("Not Created");
        //    }
        //    var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
        //    var subject = context.Subjects.FirstOrDefault(u => u.Name== dto.SubjectName);

        //    var e = new Enrollment()
        //    {
        //        Student = student,
        //        Subject = subject,
        //        EnrollmentDate = dto.EnrollmentDate,
        //        Grade = dto.Grade

        //    };
        //    context.Enrollments.Add(e);
        //    context.SaveChanges();
        //    return Ok(dto);
        //}

        //Mapper
        [HttpPost]
        public IActionResult Create(CreateEnrollmentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Not Created");
            }
            var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
            var subject = context.Subjects.FirstOrDefault(u => u.Name == dto.SubjectName);

            var enroll = mapper.Map<Enrollment>(dto);
            enroll.Student = student;
            enroll.Subject = subject;
            context.Enrollments.Add(enroll);
            context.SaveChanges();
            var res = mapper.Map<EnrollmentDTO>(enroll);

            return Ok(res);
        }


        //DTO
        //[HttpPut]
        //public IActionResult Update(UpdateEnrollmentDTO dto, int id )
        //{
        //    var enroll = context.Enrollments.FirstOrDefault(u => u.Id == id);
        //    if (enroll == null)
        //    {
        //        return NotFound("Not Found");
        //    }
        //    if (dto == null)
        //    {
        //        return BadRequest("bad");
        //    }
        //    var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
        //    var subject = context.Subjects.FirstOrDefault(u => u.Name == dto.SubjectName);

        //    enroll.Grade = dto.Grade;
        //    enroll.EnrollmentDate = dto.EnrollmentDate;
        //    enroll.Student = student;
        //    enroll.Subject = subject;
        //    context.SaveChanges();
        //    return Ok(dto);
        //}


        //Mapper
        [HttpPut]
        public IActionResult Update(UpdateEnrollmentDTO dto, int id)
        {
            var enroll = context.Enrollments.FirstOrDefault(u => u.Id == id);
            if (enroll == null)
            {
                return NotFound("Not Found");
            }
            if (dto == null)
            {
                return BadRequest("bad");
            }
            var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
            var subject = context.Subjects.FirstOrDefault(u => u.Name == dto.SubjectName);

            mapper.Map(dto, enroll);
            enroll.Student = student;
            enroll.Subject = subject;
            context.SaveChanges();

            var res = mapper.Map<EnrollmentDTO>(enroll);
            return Ok(res);
        }
        [HttpPatch]
        public IActionResult UpdatebyPatch(UpdateEnrollmentDTO dto, int id)
        {
            var enroll = context.Enrollments.FirstOrDefault(u => u.Id == id);
            if (enroll == null)
            {
                return NotFound("Not Found");
            }
            if (dto == null)
            {
                return BadRequest("bad");
            }
            var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
            var subject = context.Subjects.FirstOrDefault(u => u.Name == dto.SubjectName);

            enroll.Grade = dto.Grade;
            context.SaveChanges();
            return Ok(dto);
        }

        [HttpDelete]
        public IActionResult Delete( int id)
        {
            var enroll = context.Enrollments.FirstOrDefault(u => u.Id == id);
            if (enroll == null)
            {
                return NotFound("Not Found");
            }
            context.Enrollments.Remove(enroll);

            context.SaveChanges();
            return NoContent();
        }

    }
}
//{
//    {
//        "studentName": "Mariam Hassan",
//    "subjectName": "English",
//    "enrollmentDate": "2026-08-02T00:00:00",
//    "grade": 100}
//}