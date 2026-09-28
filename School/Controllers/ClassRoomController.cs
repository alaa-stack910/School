//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School.DTO.ClassRoomDTOs;
//using School.DTO.DepartmentDTOs;
//using School.Mapping;
//using School.Model;

//namespace School.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClassRoomController : ControllerBase
//    {
//        //DTO
//        //private readonly AppContexts appContexts;

//        //public ClassRoomController()
//        //{
//        //    appContexts = new AppContexts();
//        //}

//        //Mapper
//        private readonly AppContexts appContexts;
//        private readonly IMapper mapper;

//        public ClassRoomController(AppContexts appContexts)
//        {
//            this.appContexts = appContexts;
//        }


//        //DTO
//        //[HttpGet]
//        //public IActionResult GetAll()
//        //{
//        //    var te = appContexts.ClassRooms.ToList();
//        //    List<ClassRoomDTO> result = new List<ClassRoomDTO>();
//        //    foreach (var classRoom in te)
//        //    {
//        //        var det = new ClassRoomDTO
//        //        {
//        //            Id = classRoom.Id,
//        //            Name = classRoom.Name,
//        //            GradeLevel = classRoom.GradeLevel,
//        //            Capacity = classRoom.Capacity
//        //        };
//        //        result.Add(det);
//        //    }
//        //    return Ok(result);

//        //}


//        //Mapper
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var te = appContexts.ClassRooms.ToList();
//            var result = mapper.Map<List<ClassRoomDTO>>(te);
//            return Ok(result);

//        }



//        //DTO
//        //[HttpGet("WithId")]

//        //public IActionResult GetId(int id)
//        //{
//        //    var te = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//        //    var clas= new ClassRoomDTO
//        //    {
//        //        Id = te.Id,
//        //        Name = te.Name,
//        //        GradeLevel = te.GradeLevel,
//        //        Capacity = te.Capacity
//        //    };

//        //    return Ok(clas);
//        //}

//        //Mapper
//        [HttpGet("WithId")]

//        public IActionResult GetId(int id)
//        {
//            var te = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//            var clas = mapper.Map<ClassRoomDTO>(te);
//            return Ok(clas);
//        }

//        //DTO
//        //[HttpPost]

//        //public IActionResult CreateClass(CreateClassRoom t)
//        //{
//        //    if (t == null)
//        //    {
//        //        return BadRequest("Not Created");
//        //    }
//        //    var clas = new ClassRoom
//        //    {
//        //        Name = t.Name,
//        //        GradeLevel = t.GradeLevel,
//        //        Capacity = t.Capacity
//        //    };
//        //    appContexts.ClassRooms.Add(clas);
//        //    appContexts.SaveChanges();
//        //    return Ok(t);
//        //}


//        //Mapper
//        [HttpPost]

//        public IActionResult CreateClass(CreateClassRoom t)
//        {
//            if (t == null)
//            {
//                return BadRequest("Not Created");
//            }
//            var clas = mapper.Map<ClassRoom>(t);
//            appContexts.ClassRooms.Add(clas);
//            appContexts.SaveChanges();
//            var res = mapper.Map<ClassRoomDTO>(clas);

//            return Ok(res);
//        }

//        //DTO
//        //[HttpPut]

//        //public IActionResult UpdateClass(UpdateClassRoom t, int id)
//        //{
//        //    var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//        //    if (t == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    dep.Name = t.Name;
//        //        dep.GradeLevel = t.GradeLevel;
//        //        dep.Capacity = t.Capacity;

//        //    appContexts.SaveChanges();
//        //    return Ok(t);
//        //}


//        //Mapper

//        [HttpPut]

//        public IActionResult UpdateClass(UpdateClassRoom t, int id)
//        {
//            var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            mapper.Map(t, dep);
//            appContexts.SaveChanges();
//            var res = mapper.Map<ClassRoomDTO>(dep);
//            return Ok(t);
//        }


//        [HttpPatch]
//        public IActionResult PartUpdateDepartment(ClassRoom t, int id)
//        {
//            var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            dep.Name = t.Name;
//            dep.GradeLevel = t.GradeLevel;
//            dep.Capacity = t.Capacity;
//            appContexts.SaveChanges();
//            return Ok(dep);
//        }


//        [HttpDelete]
//        public IActionResult DeleteClass(int id)
//        {
//            var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
//            if (dep == null)
//            {
//                return NotFound();
//            }
//            appContexts.ClassRooms.Remove(dep);
//            appContexts.SaveChanges();
//            return Ok(dep);
//        }
//    }
//}
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.ClassRoomDTOs;
using School.DTO.DepartmentDTOs;
using School.Mapping;
using School.Model;
using School.Repo.Interface;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IGenericRepo<ClassRoom> repo;

        private readonly IMapper mapper;



        public ClassRoomController(IGenericRepo<ClassRoom> repos)
        {
            repo = repos;
            mapper = new MapperConfiguration(g => g.AddProfile<ClassRoomProfile>()).CreateMapper();

        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var te = repo.GetAll();
            var result = mapper.Map<List<ClassRoomDTO>>(te);
            return Ok(result);

        }

        [HttpGet("WithId")]

        public IActionResult GetId(int id)
        {
            var te = repo.GetById(id);
            var clas = mapper.Map<ClassRoomDTO>(te);
            return Ok(clas);
        }

       
        [HttpPost]

        public IActionResult CreateClass(CreateClassRoom t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var clas = mapper.Map<ClassRoom>(t);
            repo.Add(clas);
            var res = mapper.Map<ClassRoomDTO>(clas);

            return Ok(res);
        }

       
        [HttpPut]

        public IActionResult UpdateClass(UpdateClassRoom t, int id)
        {
            var dep = repo.GetById (id);
            if (t == null)
            {
                return NotFound();
            }
            mapper.Map(t, dep);
            repo.Update(dep);
            var res = mapper.Map<ClassRoomDTO>(dep);
            return Ok(res);
        }


        //[HttpPatch]
        //public IActionResult PartUpdateDepartment(ClassRoom t, int id)
        //{
        //    var dep = appContexts.ClassRooms.FirstOrDefault(o => o.Id == id);
        //    if (t == null)
        //    {
        //        return NotFound();
        //    }
        //    dep.Name = t.Name;
        //    dep.GradeLevel = t.GradeLevel;
        //    dep.Capacity = t.Capacity;
        //    appContexts.SaveChanges();
        //    return Ok(dep);
        //}


        [HttpDelete]
        public IActionResult DeleteClass(int id)
        {
            var dep = repo.GetById(id);
            if (dep == null)
            {
                return NotFound();
            }
            repo.Delete(dep);
            return Ok(dep);
        }
    }
}
