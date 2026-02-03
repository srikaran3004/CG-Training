using System;
class Program
{
    public static void Main(String[] args)
    {
        List<Student> std = new List<Student>
        {
            new Student{Name="Srikaran",Age=21,Marks=99},
            new Student{Name="Siva",Age=20,Marks=95},
            new Student{Name="Aditya",Age=22,Marks=99},
            new Student{Name="Shubhanshu",Age=19,Marks=99},
            new Student{Name="Jyoti",Age=20,Marks=100},
        };
        std.Sort(new StdComparer());
        foreach(var s in std)
        {
            Console.WriteLine($"{s.Name} {s.Age} {s.Marks}");
        }
    }
}
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Marks { get; set; }
}

class StdComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x.Marks != y.Marks)
        {
            return y.Marks.CompareTo(x.Marks);
        }
        return x.Age.CompareTo(y.Age);
    }
}