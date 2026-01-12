// using System;
// using System.Diagnostics;
// using System.Collections.Generic;
// using System.ComponentModel;

// //class Program
// //{
// //    static void Main()
// //    {
// //        //Trace.Listeners.Add(new ConsoleTraceListener()); -> This line is commented out to avoid console output.
// //        Trace.WriteLine("Application started");

// //        int a = 10;
// //        int b = 0;
// //        try
// //        {
// //            int result = a / b;
// //            Console.WriteLine(result);
// //        }
// //        catch (Exception ex)
// //        {
// //            Trace.WriteLine("Exception occurred: " + ex.Message);
// //        }
// //        Trace.WriteLine("Application ended");
// //        //Trace.WriteLine it sends output to trace listeners used for logging and debugging.
// //        //Console.WriteLine is used to output the result to the console.
// //    }
// //}
// class User
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         //Trace.Listeners.Add(new ConsoleTraceListener());

//         //Trace.WriteLine("Program started");

//         //PerformCalculation(10, 5);
//         //PerformCalculation(10, 0);
//         //int total = 0;

//         //for (int i = 1; i <= 5; i++)
//         //{
//         //    total += i;
//         //}
//         //Trace.WriteLine("Program ended");
//         // List<User> users = new List<User>();
//         // users.Add(new User { Name = "Sri", Age = 22 });
//         // users.Add(new User { Name = "Siva", Age = 32 });
//         // users.Add(new User { Name = "Pavan", Age = 68 });
//         // users.Add(new User { Name = "Subh", Age = 63 });
//         // users.Add(new User { Name = "Arun", Age = 52 });
//         // foreach (var user in users)
//         // {
//         //     Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
//         // }
//         // Queue<int> queue = new Queue<int>();
//         // queue.Enqueue(45);
//         // queue.Enqueue(55);
//         // queue.Enqueue(65);
//         // queue.Enqueue(75);
//         // queue.Enqueue(25);
//         // while (queue.Count > 0)
//         // {
//         //    Console.Write(queue.Dequeue() + " ");
//         // }
//         int a=5;
//         int b=10;
//         int c=Add(a,b);
//         Console.WriteLine(c);
//     }
//     public static int Add(int a,int b)
//     {
//         return a+b;
//     }
//     //static void PerformCalculation(int a, int b)
//     //{
//     //    Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

//     //    if (b == 0)
//     //    {
//     //        Trace.WriteLine("Error: Division by zero detected");
//     //        return;
//     //    }

//     //    int result = Divide(a, b);

//     //    Trace.WriteLine($"Calculation successful | Result={result}");
//     //    Trace.WriteLine("Exiting PerformCalculation");
//     //}

//     //static int Divide(int x, int y)
//     //{
//     //    Trace.WriteLine($"Dividing values | x={x}, y={y}");
//     //    return x / y;
//     //}
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     public static void Main(string[] args)
//     {
//         // Student s1 = new Student("Srikaran", 90);
//         // Student s2 = new Student("Siva", 60);
//         // Student s3 = new Student("Pavan", 85);
//         // List<Student> students = new List<Student> { s1, s2, s3 };
//         // List<int>nums=new List<int>{3,5,4,6,2};
//         // int first = nums.First();
//         // Console.WriteLine(first);
//         // int res=nums.First(n=>n>3);
//         // Console.WriteLine(res);
//         // int res1=nums.Last();
//         // Console.WriteLine(res1);
//         // int res2=nums.Last(n=>n>5);
//         // Console.WriteLine(res2);
//         // int res3=nums.Single(n=>n==2);
//         // Console.WriteLine(res3);
//         // var res = students
//         //     .OrderBy(s => s.Marks)
//         //     .Select(s => new
//         //     {
//         //         s.Name,
//         //         Grade = s.Marks > 60 ? "Pass" : "Fail"
//         //     });

//         // foreach (var item in res)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }

//         //OrderByDesc
//         // var res1 = students
//         //     .OrderByDescending(s => s.Marks)
//         //     .Select(s => new
//         //     {
//         //         s.Name,
//         //         Grade = s.Marks > 60 ? "Pass" : "Fail"
//         //     });

//         // foreach (var item in res1)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }

//         //OrderBy and thenBy
//         // var res1 = students
//         // .OrderByDescending(s => s.Marks)
//         // .ThenBy(s => s.Name)
//         // .Select(s => new
//         // {
//         //     s.Name,
//         //     Grade = s.Marks > 60 ? "Pass" : "Fail"
//         // });

//         // foreach (var item in res1)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }


//         // foreach (var item in result)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }
//         // Console.WriteLine(result.GetType());

//         //ToList()
//         // var doToList = students.Select(s => new
//         // {
//         //     s.Name,
//         //     Grade = s.Marks > 60 ? "Pass" : "Fail"
//         // }).ToList();

//         // foreach (var item in doToList)
//         // {
//         //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
//         // }
//     }
// }
// class Student
// {
//     public string Name { get; set; }
//     public int Marks { get; set; }
//     public Student(string name, int marks)
//     {
//         Name = name;
//         Marks = marks;
//     }
// }

using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, string> d = new Dictionary<string, string>
        {
            {"Srikaran","CSE"},
            {"Pavan","CSE"},
            {"Shubanshu","EEE"},
            {"Siva","DSML"},
            {"Masoom","EEE"},
            {"Aditya","DSML"}
        };
        //GroupBy
        // var groupBy=d.GroupBy(s=>s.Value);
        // foreach(var val in groupBy)
        // {
        //     Console.WriteLine($"Department: {val.Key}");
        //     foreach(var std in val)
        //     {
        //         Console.WriteLine(std.Key);
        //     }
        // }
        // Console.WriteLine(groupBy.GetType());

        //ToLookUp
        // var lookUp = d.ToLookup(s => s.Value);
        // foreach (var val in lookUp)
        // {
        //     Console.WriteLine($"Department: {val.Key}");
        //     foreach (var std in val)
        //     {
        //         Console.WriteLine(std.Key);
        //     }
        // }
        // Console.WriteLine(lookUp.GetType());

        var studentsList = new List<Student>()
        {
            new Student { Id = 1, Name = "Sri", DeptId = 101 },
            new Student { Id = 2, Name = "Siva", DeptId = 102 },
            new Student { Id = 3, Name = "Pavan", DeptId = 101 },
            new Student { Id = 4, Name = "Subhanshu", DeptId = 103 },
        };
        var departments = new List<Department>()
        {
            new Department { DeptId = 101, DeptName = "CSE" },
            new Department { DeptId = 102, DeptName = "ECE" },
            new Department {DeptId = 103, DeptName ="EEE"}
        };

        //Join()
        var result = studentsList.Join(
            departments,
            s => s.DeptId,
            d => d.DeptId,
            (s, d) => new
            {
                StudentName = s.Name,
                DepartmentName = d.DeptName
            });
        foreach (var item in result)
        {
            Console.WriteLine($"{item.StudentName} - {item.DepartmentName}");
        }

        //groupJoin
        var groupJoinResult = departments.GroupJoin(
            studentsList,
            d => d.DeptId,
            s => s.DeptId,
            (d, students) => new
            {
                Department = d.DeptName,
                Students = students
            });

        foreach (var dept in groupJoinResult)
        {
            Console.WriteLine($"Department: {dept.Department}");
            foreach (var student in dept.Students)
            {
                Console.WriteLine($"  Student: {student.Name}");
            }
        }

    }
}
class Student
{
    public int Id;
    public string Name;
    public int DeptId;
}

class Department
{
    public int DeptId;
    public string DeptName;
}

