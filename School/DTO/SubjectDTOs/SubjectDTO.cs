using School.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School.DTO.SubjectDTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaxGrade { get; set; }
        public string TeacherName { get; set; }

    }
}
