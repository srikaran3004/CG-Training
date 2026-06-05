using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToManyEF.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int Salary { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation Property
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
