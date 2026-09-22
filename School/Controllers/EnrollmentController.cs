using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.DTO.EnrollmentDTOs;
using School.Model;
using Microsoft.EntityFrameworkCore;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppContexts context;

        public EnrollmentController()
        {
            context = new AppContexts();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var all = context.Enrollments.Include(i=>i.Student).Include(h=>h.Subject).ToList();
            List<EnrollmentDTO> dto = new List<EnrollmentDTO>();
            foreach (var e in all)
            {
                var dtoe = new EnrollmentDTO()
                {
                    Id = e.Id,
                    StudentName = e.Student.FirstName + " " + e.Student.LastName,
                    Grade = e.Grade,
                    EnrollmentDate = e.EnrollmentDate,
                    SubjectName = e.Subject.Name
                };
                dto.Add(dtoe);
            }
            return Ok(dto);
        }

        [HttpGet("ID")]
        public IActionResult GetID(int id)
        {
            var enroll = context.Enrollments.Include(i => i.Student).Include(h => h.Subject).FirstOrDefault(u=>u.Id==id);
            var dtoe = new EnrollmentDTO()
            {
                Id = enroll.Id,
                    StudentName = enroll.Student.FirstName + " " + enroll.Student.LastName,
                Grade = enroll.Grade,
                EnrollmentDate = enroll.EnrollmentDate,
                SubjectName = enroll.Subject.Name
            };
            return Ok(dtoe);
        }


        [HttpPost]
        public IActionResult Create(CreateEnrollmentDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Not Created");
            }
            var student = context.Students.FirstOrDefault(u => u.FirstName + " " + u.LastName == dto.StudentName);
            var subject = context.Subjects.FirstOrDefault(u => u.Name== dto.SubjectName);

            var e = new Enrollment()
            {
                Student = student,
                Subject = subject,
                EnrollmentDate = dto.EnrollmentDate,
                Grade = dto.Grade

            };
            context.Enrollments.Add(e);
            context.SaveChanges();
            return Ok(dto);
        }

        [HttpPut]
        public IActionResult Update(UpdateEnrollmentDTO dto, int id )
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
            enroll.EnrollmentDate = dto.EnrollmentDate;
            enroll.Student = student;
            enroll.Subject = subject;
            context.SaveChanges();
            return Ok(dto);
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