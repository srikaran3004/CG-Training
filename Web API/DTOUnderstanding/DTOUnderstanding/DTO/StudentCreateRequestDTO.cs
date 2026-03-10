namespace DTOUnderstanding.DTO
{
    public class StudentCreateRequestDTO
    {
        public string Name { get; set; }=string.Empty;
        public int Age { get; set; }
        public decimal CourseFeePaid { get; set; }
    }
}
