using System;
using System.Data.Common;
// class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }

//     public void Deconstruct(out int id, out string name)
//     {
//         id = Id;
//         name = Name;
//     }
// }
class Program
{
    static void Main()
    {
        // Console.WriteLine("Creating objects...!");
        // CreateObjects();

        // Console.WriteLine("Forcing garbage collection...");
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        // Console.WriteLine("Garbage collection completed...");
        // var student = (ID: 101, Name: "Srikaran");
        // Console.WriteLine(student.GetType());
        // (int, string) student2 = (102, "Sri");
        // Console.WriteLine(student2.GetType());
        // var std = new { Name = "Srikran", age = 21 }; //We create anonymous types to quickly group related data without creating a separate class, mainly for temporary or read-only use.
        // Console.WriteLine(std.GetType());
        //We can get multiple return values instead of using out.
        // static (int Sum,int Average,int Mul,int Div) Calculate(int a,int b)
        // {
        //     return (a+b,(a+b)/2,a*b,a/b);
        // }
        // var res=Calculate(10,20);
        // Console.WriteLine(res);
        // static(bool isValid, string Message) Validate(string username)
        // {
        //     if (string.IsNullOrEmpty(username))
        //     {
        //         return (false,"Username is requried");
        //     }
        //     return (true,"Valid user");
        // }
        // var response=Validate("Admin");
        // Console.WriteLine(response.Message);

        // var a = (Id: 1, Name: "Srikaran", age: 21);
        // Console.WriteLine(a.Id);
        // var(id,name,_)=a;
        // Console.WriteLine(id);
        // Console.WriteLine(id.GetType());
        // var (_, userName, _) = a; //Discards-> when we want to skip other values like id,age.
        // Console.WriteLine(userName);
        // var s = new Student { Id = 1, Name = "Amit" };
        // Console.WriteLine(s.GetType());
        // var (sid, sname) = s; //deconstruction
        // Console.WriteLine(sid);
        // Console.WriteLine(sname);
        // static (int Min, int Max) FindMinMax(int[] numbers)
        // {
        //     return (numbers.Min(), numbers.Max());
        // }
        // var (min, max) = FindMinMax(new int[] { 3, 5, 1, 9, 2 });
        // Console.WriteLine(min + " " + max);
        // int[] numbers = { 1, 2, 3, 4, 5, 6 };
        // var evenNumbers = numbers.Where(n => n % 2 == 0);
        // Console.WriteLine("Even numbers are:");
        // foreach (var n in evenNumbers)
        // {
        //     Console.WriteLine(n);
        // }
        // Console.WriteLine(evenNumbers.GetType()); //evenNumbers . Get Type() -> IEnumerab1e Interface
        //In C# we can use foreach only on Ienumerable Interfaces, by default all collections donot allow to use foreach iteration.
        //All collections extend Ienumerable so we can use foreach loop on Lists.

        // var res=numbers.Where(n=>n>3).Select(n=>n*2);
        // foreach(int x in res)
        // {
        //     Console.WriteLine(x);
        // }
        // Console.WriteLine(res.GetType());
        // var students = new List<Student>
        // {
        //     new Student { Name = "Sri", Marks = 75 },
        //     new Student { Name = "Siva", Marks = 55 },
        //     new Student { Name = "Pavan", Marks = 90 }
        // };
        // var result = students.Select(s => new
        // {
        //     s.Name,
        //     Grade = s.Marks > 60 ? "Pass" : "Fail"
        // }).ToList();
        // foreach (var r in result)
        // {
        //     Console.WriteLine($"{r.Name} - {r.Grade}");
        // }
        // Console.WriteLine(result.GetType());

        //Lambda Exp with multiple params
        // int[] numbers = { 10, 20, 30, 40 };
        // var indexedData = numbers.Select((value, index) =>
        //     $"Index: {index}, Value: {value}");
        // foreach (var item in indexedData)
        // {
        //     Console.WriteLine(item);
        // }
        //OrderBy()-> Ascending 
        //OrderByDescending()->Descending (These create new Enumerables when used instead of editing in original one).

        // int[]arr={2,10,3,234,23,23,42,34,23,4,1,434,6,56,46};
        // var asc=arr.OrderBy(n=>n);
        // var des=arr.OrderByDescending(n=>n);
        // Console.WriteLine("Ascending Order: ");
        // foreach(var i in asc)
        // {
        //     Console.WriteLine(i);
        // }
        // Console.WriteLine("Descending Order: ");
        // foreach(var j in des)
        // {
        //     Console.WriteLine(j);
        // }
        // var students = new List<Student>
        // {
        //     new Student { Name = "Sri", Marks = 75 },
        //     new Student { Name = "Siva", Marks = 55 },
        //     new Student { Name = "Pavan", Marks = 90 },
        //     new Student { Name = "Amit", Marks = 65 }
        // };
        // var nameAsc = students.OrderBy(s => s.Name);
        // var nameDesc = students.OrderByDescending(s => s.Name);
        // var marksAsc = students.OrderBy(s => s.Marks);
        // var marksDesc = students.OrderByDescending(s => s.Marks);
        // Console.WriteLine("Order by Name (Ascending):");
        // foreach (var s in nameAsc)
        //     Console.WriteLine($"{s.Name} - {s.Marks}");

        // Console.WriteLine("Order by Name (Descending):");
        // foreach (var s in nameDesc)
        //     Console.WriteLine($"{s.Name} - {s.Marks}");

        // Console.WriteLine("Order by Marks (Ascending):");
        // foreach (var s in marksAsc)
        //     Console.WriteLine($"{s.Name} - {s.Marks}");

        // Console.WriteLine("Order by Marks (Descending):");
        // foreach (var s in marksDesc)
        //     Console.WriteLine($"{s.Name} - {s.Marks}");
        using (ResourceHandler handler = new ResourceHandler())
        {
            Console.WriteLine("Using resource...");
        }

        Console.WriteLine("End of program.");
    }
    // static void CreateObjects()
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         new MyClass();
    //     }
    // }
}
class ResourceHandler : IDisposable
{
    public ResourceHandler()
    {
        Console.WriteLine("Resource acquired.");
    }
    public void Dispose()
    {
        Console.WriteLine("Resource disposed.");
    }
}

// class Student
// {
//     public string? Name { get; set; }
//     public int Marks { get; set; }
// }
// class MyClass
// {
//     ~MyClass()
//     {
//         Console.WriteLine("Finalizer called, object collected");
//     }
// }
//A finalizer is the last chance an object, gets to clean up resources before it is destroyed by GC.
//In C# finalizer looks as destructor.
// LINQ (Language Integrated Query) is a feature of C# that allows developers to query, filter, transform,
// and manipulate data using SQL-Iike syntax directly inside thq C# language.

