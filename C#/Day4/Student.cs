using System;

class Student
{
    private string name = "";
    private int age;
    private double marks;
    private string password = "";

    public int RegistrationNumber { get; private set; }
    public int AdmissionYear { get; init; }

    public Student(int regNo)
    {
        RegistrationNumber = regNo;
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
                name = value;
            else
                Console.WriteLine("Name can't be empty");
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
            else
                Console.WriteLine("Age must be greater than 0");
        }
    }

    public double Marks
    {
        get { return marks; }
        set
        {
            if (value >= 0 && value <= 100)
                marks = value;
            else
                Console.WriteLine("Marks should be between 0 and 100");
        }
    }

    public string Result => marks >= 40 ? "Pass" : "Fail";

    public double Percentage => (marks / 100) * 100;

    public string Password
    {
        set
        {
            if (value.Length >= 6)
                password = value;
            else
                Console.WriteLine("Password length must be at least 6 characters");
        }
    }
    // Indexer Overloading

class EmployeeDirectory
{
    private Dictionary<int, string> employees = new Dictionary<int, string>();

    public string this[int id]
    {
        get { return employees[id]; }
        set { employees[id] = value; }
    }

    public string this[string name]
    {
        get
        {
            return employees.FirstOrDefault(e => e.Value == name).Value;
        }
    }
}
}
