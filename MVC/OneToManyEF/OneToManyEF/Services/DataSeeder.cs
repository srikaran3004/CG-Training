using OneToManyEF.Data;
using OneToManyEF.Models;

namespace OneToManyEF.Services
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Departments.Any())
            {
                var departments = new List<Department>
                {
                    new Department { DepartmentName = "HR" },
                    new Department { DepartmentName = "IT" },
                    new Department { DepartmentName = "Finance" },
                    new Department { DepartmentName = "Marketing" },
                    new Department { DepartmentName = "Operations" }
                };

                context.Departments.AddRange(departments);
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Ravi Kumar", Salary = 50000, DepartmentId = 1 },
                    new Employee { EmployeeName = "Priya Sharma", Salary = 60000, DepartmentId = 2 },
                    new Employee { EmployeeName = "Amit Patel", Salary = 55000, DepartmentId = 3 },
                    new Employee { EmployeeName = "Sneha Reddy", Salary = 70000, DepartmentId = 2 },
                    new Employee { EmployeeName = "Vikram Singh", Salary = 45000, DepartmentId = 4 },
                    new Employee { EmployeeName = "Anjali Nair", Salary = 65000, DepartmentId = 5 },
                    new Employee { EmployeeName = "Karthik Rao", Salary = 48000, DepartmentId = 1 },
                    new Employee { EmployeeName = "Deepa Menon", Salary = 72000, DepartmentId = 3 }
                };

                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}
