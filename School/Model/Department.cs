using 
System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace School.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
       public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Teacher> Teachers { get; set; } =new List<Teacher>();
    }
}
