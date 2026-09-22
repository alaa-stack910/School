using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.DepartmentDTOs;
using School.Mapping;
using School.Model;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //DTO
        //    private readonly AppContexts appContexts;

        //public TeacherController()
        //    {
        //    appContexts = new AppContexts();

        //}

        private readonly AppContexts appContexts;
        private readonly IMapper mapper;
        public DepartmentsController()
        {
            appContexts = new AppContexts();
            mapper = new MapperConfiguration(g => g.AddProfile<DepartmentProfile>()).CreateMapper();

        }

        //DTO
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var te = appContexts.Departments.ToList();
        //    List<DepartmentDTO> result = new List<DepartmentDTO>();
        //    foreach (var department in te)
        //    {
        //        var det = new DepartmentDTO
        //        {
        //            DepartmentId = department.DepartmentId,
        //            DepartmentName = department.Name,
        //            Description = department.Description
        //        };
        //        result.Add(det);
        //    }
        //    return Ok(result);

        //}

        //mapper
        [HttpGet]
        public IActionResult GetAll()
        {
            var te = appContexts.Departments.ToList();
            var result = mapper.Map<List<DepartmentDTO>>(te);
            return Ok(result);

        }

        //DTO

        //[HttpGet("WithId")]

        //public IActionResult GetId(int id)
        //{
        //    var te = appContexts.Departments.FirstOrDefault(k => k.DepartmentId == id);

        //    var dep = new DepartmentDTO()
        //    {
        //        DepartmentId = te.DepartmentId,
        //        DepartmentName = te.Name,
        //        Description = te.Description
        //    };
        //    return Ok(dep);
        //}

        //Mapper
        [HttpGet("WithId")]

        public IActionResult GetId(int id)
        {
            var te = appContexts.Departments.FirstOrDefault(k => k.DepartmentId == id);

            if (te == null)
            {
                return NotFound();
            }
            var result = mapper.Map<DepartmentDTO>(te);

            return Ok(result);
        }


        //DTO
        //[HttpPost]

        //    public IActionResult CreateDepartment(CreateDepartmentDTO t)
        //    {
        //        if (t == null)
        //        {
        //            return BadRequest("Not Created");
        //        }
        //        var department = new Department
        //        {
        //            Name = t.DepartmentName,
        //            Description = t.Description
        //        };  
        //    appContexts.Departments.Add(department);
        //        appContexts.SaveChanges();
        //        return Ok(t);
        //    }

        //Mapper
        [HttpPost]

        public IActionResult CreateDepartment(CreateDepartmentDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }
            var department = mapper.Map<Department>(t);
            appContexts.Departments.Add(department);
            appContexts.SaveChanges();

            var res = mapper.Map<DepartmentDTO>(department);

            return Ok(res);
        }


        //DTO
        //[HttpPut]

        //public IActionResult UpdateDepartment(UpdateDepartmentDTO t,int id)
        //{
        //    var dep = appContexts.Departments.FirstOrDefault(o=>o.DepartmentId==id);
        //    if (t == null)
        //    {
        //        return NotFound();
        //    }
        //    dep.Name = t.DepartmentName;
        //    dep.Description = t.Description;

        //    appContexts.SaveChanges();
        //    return Ok(t);
        //}

        //Mapper
        [HttpPut]

        public IActionResult UpdateDepartment(UpdateDepartmentDTO t, int id)
        {
            var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
            if (t == null)
            {
                return NotFound();
            }
            mapper.Map(t, dep);
            appContexts.SaveChanges();
            var res = mapper.Map<DepartmentDTO>(dep);

            return Ok(res);
        }



        [HttpPatch]
        public IActionResult PartUpdateDepartment(Department t, int id)
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











//    //var te = appContexts.Departments.Include(j => j.Teachers).FirstOrDefault(o => o.DepartmentId == id);
//    //var ve = appContexts.Departments.First(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.FirstOrDefault(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.Single(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.SingleOrDefault(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.Last(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.LastOrDefault(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.Where(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.ElementAt(1);
//    //var ve = appContexts.Departments.Any(i => i.DepartmentId == id);
//    //var ve = appContexts.Departments.All(i => i.DepartmentId == id);


//    ////error
//    //var ve = appContexts.Departments.Select(g => g.Name).Contains("S") ;
//var ve = appContexts.Departments.SelectMany(i=>i.DepartmentId);

