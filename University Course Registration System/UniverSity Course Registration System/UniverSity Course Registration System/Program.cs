using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
    // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter Course Code: ");
                            string code = Console.ReadLine();

                            Console.Write("Enter Course Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Credits (1-4): ");
                            int credits = int.Parse(Console.ReadLine());

                            Console.Write("Enter Max Capacity (default 50): ");
                            string capInput = Console.ReadLine();
                            int capacity = string.IsNullOrWhiteSpace(capInput) ? 50 : int.Parse(capInput);

                            Console.Write("Enter Prerequisites (comma-separated, or Enter for none): ");
                            string prereqInput = Console.ReadLine();
                            List<string> prereqs = string.IsNullOrWhiteSpace(prereqInput)
                                ? null
                                : prereqInput.Split(',').Select(p => p.Trim()).ToList();

                            system.AddCourse(code, name, credits, capacity, prereqs);
                            break;

                        case "2":
                            Console.Write("Enter Student ID: ");
                            string id = Console.ReadLine();

                            Console.Write("Enter Name: ");
                            string studentName = Console.ReadLine();

                            Console.Write("Enter Major: ");
                            string major = Console.ReadLine();

                            Console.Write("Enter Max Credits (default 18): ");
                            string maxCredInput = Console.ReadLine();
                            int maxCredits = string.IsNullOrWhiteSpace(maxCredInput) ? 18 : int.Parse(maxCredInput);

                            Console.Write("Enter Completed Courses (comma-separated, or Enter for none): ");
                            string completedInput = Console.ReadLine();
                            List<string> completed = string.IsNullOrWhiteSpace(completedInput)
                                ? null
                                : completedInput.Split(',').Select(c => c.Trim()).ToList();

                            system.AddStudent(id, studentName, major, maxCredits, completed);
                            break;

                        case "3":
                            Console.Write("Enter Student ID: ");
                            string sid = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string ccode = Console.ReadLine();

                            system.RegisterStudentForCourse(sid, ccode);
                            break;

                        case "4":
                            Console.Write("Enter Student ID: ");
                            string dsid = Console.ReadLine();

                            Console.Write("Enter Course Code: ");
                            string dcode = Console.ReadLine();

                            system.DropStudentFromCourse(dsid, dcode);
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Enter Student ID: ");
                            string schedId = Console.ReadLine();

                            system.DisplayStudentSchedule(schedId);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            Console.WriteLine("Exiting system. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

