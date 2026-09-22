using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Model;
using Microsoft.EntityFrameworkCore;
using School.DTO.DepartmentDTOs;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
            private readonly AppContexts appContexts;

            public DepartmentsController()
            {
                appContexts = new AppContexts();
            }


        [HttpGet]
        public IActionResult GetAll()
        {
            var te = appContexts.Departments.ToList();
            List<DepartmentDTO> result = new List<DepartmentDTO>();
            foreach (var department in te)
            {
                var det = new DepartmentDTO
                {
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.Name,
                    Description = department.Description
                };
                result.Add(det);
            }
            return Ok(result);

        }

        [HttpGet("WithTeacher")]

        public IActionResult GetAllWithTeacher()
        {
            var te = appContexts.Departments.Include(j => j.Teachers).ToList();
            return Ok(te);
        }

        //[HttpGet("WithId")]

        //public IActionResult GetId(int id)
        //{
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


            //    //var dep = new DepartmentDTO()
            //    //{
            //    //    DepartmentId = te.DepartmentId,
            //    //    DepartmentName = te.Name,
            //    //    Description = te.Description
            //    //};
        //    return Ok(ve);
        //}

        [HttpPost]

            public IActionResult CreateDepartment(CreateDepartmentDTO t)
            {
                if (t == null)
                {
                    return BadRequest("Not Created");
                }
                var department = new Department
                {
                    Name = t.DepartmentName,
                    Description = t.Description
                };  
            appContexts.Departments.Add(department);
                appContexts.SaveChanges();
                return Ok(t);
            }


        [HttpPut]

        public IActionResult UpdateDepartment(UpdateDepartmentDTO t,int id)
        {
            var dep = appContexts.Departments.FirstOrDefault(o=>o.DepartmentId==id);
            if (t == null)
            {
                return NotFound();
            }
            var department =new Department
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


