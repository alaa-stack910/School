namespace School.DTO.SubjectDTOs
{
    public class CreateSubjectDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MaxGrade { get; set; }
        public string TeacherName { get; set; }

    }
}
