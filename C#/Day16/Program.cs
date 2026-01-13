using System.Net;
using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {
        Type type = typeof(Employee);
        // typeof(Employee) → gets metadata (Type info) of Employee class

        // ============== PROPERTY INFO ====================

        // Employee e = new Employee();

        // PropertyInfo propId = type.GetProperty("EmpId")!;
        // // GetProperty("EmpId") → gets metadata of EmpId property

        // PropertyInfo propName = type.GetProperty("EmpName")!;
        // // GetProperty("EmpName") → gets metadata of EmpName property

        // Console.WriteLine(propId);
        // Console.WriteLine(propId.PropertyType);

        // Console.WriteLine(propName);
        // Console.WriteLine(propName.PropertyType);

        // propId.SetValue(e, 101);
        // propName.SetValue(e, "Srikaran");

        // Console.WriteLine(propId.GetValue(e));
        // Console.WriteLine(propName.GetValue(e));

        // ============ CONSTRUCTOR INFO ===================

        // ConstructorInfo ctor1 = type.GetConstructor(Type.EmptyTypes)!;
        // // GetConstructor(Type.EmptyTypes) → gets parameterless constructor

        // object obj1 = ctor1.Invoke(null);
        // // Invoke(null) → creates object using parameterless constructor
        // Console.WriteLine(ctor1);
        // Console.WriteLine(ctor1.IsPublic);
        // Console.WriteLine(ctor1.GetParameters().Length);

        // Employee emp1 = (Employee)obj1; //Convert the generic object into an Employee object.
        // ConstructorInfo ctor2 = type.GetConstructor(
        //     new Type[] { typeof(int), typeof(string) }
        // )!;//Find the constructor that takes an int and a string
        // // gets constructor with (int, string) parameters

        // object obj2 = ctor2.Invoke(new object[] { 201, "Srikaran" }); //Values are passed to constructor, constructor is executed dynamically, new obj created in memory, returns an obj
        // Employee emp2 = (Employee)obj2;
        // Console.WriteLine(emp2.EmpId);
        // Console.WriteLine(emp2.EmpName);

        //Complete flow of this block: Find constructor metadata -> Pass parameter values -> Invoke constructor -> Create object -> Cast to Employee -> Use object normally.

        // ============== PARAMETER INFO ===================
        MethodInfo method = type.GetMethod("CalculateSalary")!;
        // GetMethod("CalculateSalary") → gets metadata of method

        ParameterInfo[] parameters = method.GetParameters();
        // GetParameters() → gets all input parameters of the method

        foreach (ParameterInfo param in parameters)
        {
            Console.WriteLine(param.Name);
            // Name → parameter name

            Console.WriteLine(param.ParameterType);
            // ParameterType → data type of parameter

            Console.WriteLine(param.Position);
            // Position → order of parameter (0-based)

            Console.WriteLine(param.IsOptional);
            // IsOptional → whether parameter is optional
        }
    }
}

class Employee
{
    public int EmpId { get; set; }
    public string? EmpName { get; set; }

    public Employee()
    {
        // parameterless constructor
    }

    public Employee(int id, string name)
    {
        EmpId = id;
        EmpName = name;
    }

    public void Work()
    {
        Console.WriteLine("Employee is Working");
    }

    public double CalculateSalary(int hours, double rate)
    {
        return hours * rate;
    }
}

