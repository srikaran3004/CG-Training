using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_with_EF.Data;
using MVC_with_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_with_EF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentManagementContext _context;

        public StudentsController(StudentManagementContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int age, string city)
        {
            var student = new Student
            {
                Name = name,
                Age = age,
                City = city
            };

            _context.Students.Add(student);
            _context.SaveChanges();


            return Content("Student Created Successfully");
        }
        public IActionResult All()
        {
            var students = _context.Students.ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var s in students)
            {
                sb.Append($"{s.Id} - {s.Name} - {s.Age} - {s.City} <br>");
            }

            return Content(sb.ToString(), "text/html");
        }


        //Students/Details/1
        public IActionResult Details(int id)
        {
            var s = _context.Students.Find(id);

            if (s == null)
                return Content("Student not found");

            return Content($"{s.Id} - {s.Name} - {s.Age} - {s.City}");
        }
        public IActionResult Edit(int id, string name, int age, string city)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return Content("Student not found");

            student.Name = name;
            student.Age = age;
            student.City = city;

            _context.SaveChanges();

            return Content("Student Updated Successfully");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return Content("Student not found");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content("Student Deleted Successfully");
        }
    }
}
