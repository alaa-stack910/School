using School.Model;
using System.ComponentModel.DataAnnotations;

namespace School.DTO.EnrollmentDTOs
{
    public class EnrollmentDTO
    {
        public int Id { get; set; }

        public string StudentName { get; set; }


        public string SubjectName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public int Grade { get; set; }

    }
}
