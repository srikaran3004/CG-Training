using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<Student> ls = new List<Student>{
            new Student{Id=1,Name="Srikaran",Height=162.4f,AttendancePercentage=99f},
            new Student{Id=2,Name="Pavan",Height=null,AttendancePercentage=98f},
            new Student{Id=3,Name="Subhanshu",Height=165f,AttendancePercentage=97f},
            new Student{Id=4,Name="Aditya",Height=163.2f,AttendancePercentage=99f},
            new Student{Id=5,Name="Siva",Height=158f,AttendancePercentage=89f},
        };

        ArrayList arr = new ArrayList(ls);
        int cnt = 0;

        foreach (Student s in arr)
        {
            if (s.Height == null)
            {
                Console.WriteLine("Height Not Available");
            }
            else
            {
                Console.WriteLine(Math.Round(s.Height.Value, 1));
            }

            string res = "";
            for (int i = 0; i < s.Name.Length; i += 2)
            {
                res += s.Name[i];
            }
            Console.WriteLine("Username: " + res);

            if (s.AttendancePercentage > 75.5f)
            {
                Console.WriteLine(s.AttendancePercentage);
                cnt++;
            }
        }

        Console.WriteLine("Attendance Marked for: " + cnt);
    }
}
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float? Height { get; set; }
    public float AttendancePercentage { get; set; }
}
