//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using School.DTO.DepartmentDTOs;
//using School.Mapping;
//using School.Model;

//namespace School.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DepartmentsController : ControllerBase
//    {
//        //DTO
//        //    private readonly AppContexts appContexts;

//        //public TeacherController()
//        //    {
//        //    appContexts = new AppContexts();

//        //}

//        private readonly AppContexts appContexts;
//        private readonly IMapper mapper;
//        public DepartmentsController(AppContexts appContexts)
//        {
//            this.appContexts = appContexts;

//        mapper = new MapperConfiguration(g => g.AddProfile<DepartmentProfile>()).CreateMapper();

//        }

//        //DTO
//        //[HttpGet]
//        //public IActionResult GetAll()
//        //{
//        //    var te = appContexts.Departments.ToList();
//        //    List<DepartmentDTO> result = new List<DepartmentDTO>();
//        //    foreach (var department in te)
//        //    {
//        //        var det = new DepartmentDTO
//        //        {
//        //            DepartmentId = department.DepartmentId,
//        //            DepartmentName = department.Name,
//        //            Description = department.Description
//        //        };
//        //        result.Add(det);
//        //    }
//        //    return Ok(result);

//        //}

//        //mapper
//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var te = appContexts.Departments.ToList();
//            var result = mapper.Map<List<DepartmentDTO>>(te);
//            return Ok(result);

//        }

//        //DTO

//        //[HttpGet("WithId")]

//        //public IActionResult GetId(int id)
//        //{
//        //    var te = appContexts.Departments.FirstOrDefault(k => k.DepartmentId == id);

//        //    var dep = new DepartmentDTO()
//        //    {
//        //        DepartmentId = te.DepartmentId,
//        //        DepartmentName = te.Name,
//        //        Description = te.Description
//        //    };
//        //    return Ok(dep);
//        //}

//        //Mapper
//        [HttpGet("WithId")]

//        public IActionResult GetId(int id)
//        {
//            var te = appContexts.Departments.FirstOrDefault(k => k.DepartmentId == id);

//            if (te == null)
//            {
//                return NotFound();
//            }
//            var result = mapper.Map<DepartmentDTO>(te);

//            return Ok(result);
//        }


//        //DTO
//        //[HttpPost]

//        //    public IActionResult CreateDepartment(CreateDepartmentDTO t)
//        //    {
//        //        if (t == null)
//        //        {
//        //            return BadRequest("Not Created");
//        //        }
//        //        var department = new Department
//        //        {
//        //            Name = t.DepartmentName,
//        //            Description = t.Description
//        //        };  
//        //    appContexts.Departments.Add(department);
//        //        appContexts.SaveChanges();
//        //        return Ok(t);
//        //    }

//        //Mapper
//        [HttpPost]

//        public IActionResult CreateDepartment(CreateDepartmentDTO t)
//        {
//            if (t == null)
//            {
//                return BadRequest("Not Created");
//            }
//            var department = mapper.Map<Department>(t);
//            appContexts.Departments.Add(department);
//            appContexts.SaveChanges();

//            var res = mapper.Map<DepartmentDTO>(department);

//            return Ok(res);
//        }


//        //DTO
//        //[HttpPut]

//        //public IActionResult UpdateDepartment(UpdateDepartmentDTO t,int id)
//        //{
//        //    var dep = appContexts.Departments.FirstOrDefault(o=>o.DepartmentId==id);
//        //    if (t == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    dep.Name = t.DepartmentName;
//        //    dep.Description = t.Description;

//        //    appContexts.SaveChanges();
//        //    return Ok(t);
//        //}

//        //Mapper
//        [HttpPut]

//        public IActionResult UpdateDepartment(UpdateDepartmentDTO t, int id)
//        {
//            var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
//            if (t == null)
//            {
//                return NotFound();
//            }
//            mapper.Map(t, dep);
//            appContexts.SaveChanges();
//            var res = mapper.Map<DepartmentDTO>(dep);

//            return Ok(res);
//        }



//        [HttpPatch]
//        public IActionResult PartUpdateDepartment(Department t, int id)
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
//        public IActionResult DeleteDepartment(int id)
//        {
//            var dep = appContexts.Departments.FirstOrDefault(o => o.DepartmentId == id);
//            if (dep == null)
//            {
//                return NotFound();
//            }
//            appContexts.Departments.Remove(dep);
//            appContexts.SaveChanges();
//            return Ok(dep);
//        }


//    }
//}



using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.DTO.DepartmentDTOs;
using School.Mapping;
using School.Model;
using School.Repo.Interface;

namespace School.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {


        private readonly IGenericRepo<Department> repo;

        private readonly IMapper mapper;

        public DepartmentsController(IGenericRepo<Department> repos)
        {
            repo = repos;
            mapper = new MapperConfiguration(g => g.AddProfile<DepartmentProfile>()).CreateMapper();

        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var te = repo.GetAll();
            var result = mapper.Map<List<DepartmentDTO>>(te);
            return Ok(result);

        }

        [HttpGet("WithId")]

        public IActionResult GetId(int id)
        {
            var te = repo.GetById(id);

            if (te == null)
            {
                return NotFound();
            }
            var result = mapper.Map<DepartmentDTO>(te);

            return Ok(result);
        }


        [HttpPost]

        public IActionResult CreateDepartment(CreateDepartmentDTO t)
        {
            if (t == null)
            {
                return BadRequest("Not Created");
            }

            var d= mapper.Map<Department>(t);

            repo.Add(d);

            var res = mapper.Map<DepartmentDTO>(d);

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
            var dep = repo.GetById(id);
            if (t == null)
            {
                return NotFound();
            }
            mapper.Map(t, dep);
            repo.Update(dep);

            var res = mapper.Map<DepartmentDTO>(dep);

            return Ok(res);
        }



        //[HttpPatch]
        //public IActionResult PartUpdateDepartment(Department t, int id)
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
        public IActionResult DeleteDepartment(int id)
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















