using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneToManyEF.Data;
using OneToManyEF.Models;
using Microsoft.EntityFrameworkCore;

namespace OneToManyEF.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!_context.Departments.Any(d => d.DepartmentId == employee.DepartmentId))
            {
                ModelState.AddModelError("DepartmentId", "Please select a valid department.");
            }

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View(employee);
        }

        public IActionResult ByDepartment(int id)
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Where(e => e.DepartmentId == id)
                .ToList();

            ViewBag.DepartmentName = _context.Departments
                .Where(d => d.DepartmentId == id)
                .Select(d => d.DepartmentName)
                .FirstOrDefault();

            return View("Index", employees);
        }

        public IActionResult SalaryGreaterThan1000()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Salary > 1000)
                .OrderByDescending(e => e.Salary)
                .ToList();

            return View("Index", employees);
        }

        public IActionResult TopSalariedEmployees(int count = 5)
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .OrderByDescending(e => e.Salary)
                .Take(count)
                .ToList();

            return View("Index", employees);
        }

        public IActionResult SearchByName(string name)
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Where(e => e.EmployeeName.Contains(name))
                .ToList();

            return View("Index", employees);
        }
    }
}
