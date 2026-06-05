using System.ComponentModel.DataAnnotations;

namespace OneToManyEF.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        // Navigation Property
        public List<Employee> Employees { get; set; }
    }
}
