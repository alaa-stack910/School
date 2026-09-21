using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.ClassRoomDTOs;
using School.DTO.DepartmentDTOs;
using School.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {

        private readonly AppContexts appContexts;

        public ClassRoomController()
        {
            appContexts = new AppContexts();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var te = appContexts.ClassRooms.ToList();
            List<ClassRoomDTO> result = new List<ClassRoomDTO>();
            foreach (var classRoom in te)
            {
                var det = new ClassRoomDTO
                {
                    Id = classRoom.Id,
                    Name = classRoom.Name,
                    GradeLevel = classRoom.GradeLevel,
                    Capacity = classRoom.Capacity
                };
                result.Add(det);
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
            var te = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
            var clas= new ClassRoomDTO
            {
                Id = te.Id,
                Name = te.Name,
                GradeLevel = te.GradeLevel,
                Capacity = te.Capacity
            };

            return Ok(clas);
        }

        [HttpPost]

        public IActionResult CreateClass(CreateClassRoom t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var clas = new ClassRoom
            {
                Name = t.Name,
                GradeLevel = t.GradeLevel,
                Capacity = t.Capacity
            };
            appContexts.ClassRooms.Add(clas);
            appContexts.SaveChanges();
            return Ok(t);
        }


        [HttpPut]

        public IActionResult UpdateClass(UpdateClassRoom t, int id)
        {
            var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
            if (t == null)
            {
                return NotFound();
            }
            dep.Name = t.Name;
                dep.GradeLevel = t.GradeLevel;
                dep.Capacity = t.Capacity;
            
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
        public IActionResult DeleteClass(int id)
        {
            var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
            if (dep == null)
            {
                return NotFound();
            }
            appContexts.ClassRooms.Remove(dep);
            appContexts.SaveChanges();
            return Ok(dep);
        }
    }
}
