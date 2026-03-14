namespace FromBodyEmployee
{
    public class Employee
    {
        public static List<Employee> Employees { get; } = new List<Employee>();

        public int Id { get; set; } = 0;
        public string Name { get; set; } = "Unknown";
        public int Age { get; set; } = 18;
        public double Salary { get; set; } = 0;
    }
}
