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
        int[] numbers = { 1, 2, 3, 4, 5, 6 };
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine("Even numbers are:");
        foreach (var n in evenNumbers)
        {
            Console.WriteLine(n);
        }
        Console.WriteLine(evenNumbers.GetType());
    }

    // static void CreateObjects()
    // {
    //     for (int i = 0; i < 5; i++)
    //     {
    //         new MyClass();
    //     }
    // }
}
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