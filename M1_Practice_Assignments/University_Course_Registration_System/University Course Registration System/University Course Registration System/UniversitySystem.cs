using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            if (AvailableCourses.ContainsKey(code))
            {
                throw new ArgumentException("Course code already exists.");
            }

            Course course = new Course(code, name, credits, maxCapacity, prerequisites);
            AvailableCourses.Add(code, course);

            Console.WriteLine($"Course {code} added successfully.");
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            if (Students.ContainsKey(id))
            {
                throw new ArgumentException("Student ID already exists.");
            }

            Student student = new Student(id, name, major, maxCredits, completedCourses);
            Students.Add(id, student);

            Console.WriteLine($"Student {id} added successfully.");
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            if (!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Course not found.");
                return false;
            }

            Student student = Students[studentId];
            Course course = AvailableCourses[courseCode];

            if (course.IsFull())
            {
                Console.WriteLine("Course is full.");
                return false;
            }

            if (!student.CanAddCourse(course))
            {
                Console.WriteLine("Cannot register: prerequisites not met or credit limit exceeded or already registered.");
                return false;
            }

            bool result = student.AddCourse(course);
            if (result)
            {
                Console.WriteLine($"Registration successful! Total credits: {student.GetTotalCredits()}/{student.MaxCredits}");
            }

            return result;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return false;
            }

            Student student = Students[studentId];
            bool result = student.DropCourse(courseCode);

            if (result)
            {
                Console.WriteLine("Course dropped successfully.");
            }
            else
            {
                Console.WriteLine("Course not found in student schedule.");
            }

            return result;
        }

        public void DisplayAllCourses()
        {
            if (AvailableCourses.Count == 0)
            {
                Console.WriteLine("No courses available.");
                return;
            }

            Console.WriteLine("Available Courses:");
            foreach (Course course in AvailableCourses.Values)
            {
                Console.WriteLine(
                    $"{course.CourseCode} - {course.CourseName} | Credits: {course.Credits} | Enrollment: {course.GetEnrollmentInfo()}"
                );
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            double averageEnrollment = 0;
            if (totalCourses > 0)
            {
                averageEnrollment = AvailableCourses.Values
                    .Select(c => c.GetEnrollmentInfo())
                    .Select(e => int.Parse(e.Split('/')[0]))
                    .Average();
            }

            Console.WriteLine("System Summary:");
            Console.WriteLine($"- Total Students: {totalStudents}");
            Console.WriteLine($"- Total Courses: {totalCourses}");
            Console.WriteLine($"- Average Enrollment: {averageEnrollment:F1}");
        }
    }
}
