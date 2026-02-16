using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name="Pavan", Department="IT", Salary=60000 },
            new Employee { Name="Ravi", Department="HR", Salary=45000 },
            new Employee { Name="Kiran", Department="IT", Salary=75000 },
            new Employee { Name="Anil", Department="HR", Salary=50000 },
            new Employee { Name="Priya", Department="IT", Salary=80000 },
            new Employee { Name="Arun", Department="Finance", Salary=55000 }
        };
        var result = employees
            .GroupBy(e => e.Department)
            .Select(g => g.OrderByDescending(e => e.Salary).First());

        foreach (var e in result)
        {
            Console.WriteLine($"{e.Department} - {e.Name} - {e.Salary}");
        }


        // int[] arr = { 1, 2, 3, 4, 5, 6 };
        // var evenNumbers = from n in arr where n % 2 == 0 select n;
        // var even = arr.Where(n => n % 2 == 0).ToList();
        // Console.WriteLine("Even Numbers are: ");
        // foreach (var n in evenNumbers)
        // {
        //     Console.WriteLine(n);
        // }
        // int n = arr.Max();
        // Console.WriteLine("Max is: " + n);
        // int[] nums = { 25, 34, 10, 1, 5, 56, 32 };
        // var g = nums.Where(n => n > 30);
        // foreach (var v in g)
        // {
        //     Console.WriteLine(v);
        // }
    }
}
class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public int Salary { get; set; }
}