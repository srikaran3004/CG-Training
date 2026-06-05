using Microsoft.EntityFrameworkCore;
using OneToManyEF.Models;

namespace OneToManyEF.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "HR" },
                new Department { DepartmentId = 2, DepartmentName = "IT" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );
        }
    }
}
