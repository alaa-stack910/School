namespace School.DTO.StudentDTOs
{
    public class UpdateStudentDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string ClassRoomName { get; set; }
    }
}
