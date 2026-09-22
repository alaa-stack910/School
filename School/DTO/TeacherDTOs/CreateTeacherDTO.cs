using System.ComponentModel.DataAnnotations;

namespace School.DTO.TeacherDTOs
{
    public class CreateTeacherDTO
    {
        public string DepartmentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }



    }
}
