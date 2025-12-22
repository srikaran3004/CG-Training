using System;
class Student
{
    private string name = "";
    private int age;
    private double marks;
    private int stdId;
    public int StdId{get;set;}
    private string password="";
    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                Console.WriteLine("Name can't be empty");
            }
        }
    }
    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0) age = value;
            else
            {
                Console.WriteLine("Age must be greater then 0");
            }
        }
    }
    public double Marks
    {
        get { return marks; }
        set
        {
            if (value > 0 && value < 100) marks = value;
            else
            {
                Console.WriteLine("Marks should be btwn 0 and 100");
            }
        }
    }
    public string Result
    {
        get
        {
            if(marks>=40) return "Pass";
            else return "Fail";
        }
    }
    public string Password
    {
        set
        {
            if(value.Length>=6) password=value;
            else Console.WriteLine("Password length must be atleast 6 chars");
        }
    }
}