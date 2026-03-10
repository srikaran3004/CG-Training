namespace StudentDTO.DTO
{
    public class GetResultDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int M1 { get; set; }
        public int M2 { get; set; }
        public int Total { get; set; }
        public string Grade { get; set; } = string.Empty;
    }
}
