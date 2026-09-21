using School.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.DTO.StudentDTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        

        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string ClassRoomName { get; set; }

    }
}
