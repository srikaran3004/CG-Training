namespace StudentManagementPortal.DTOs
{
    public class CreateStudentDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Course { get; set; }
        public required string RoomNumber { get; set; }
        public required string Block { get; set; }
    }
}
