using System;
using System.Collections.Generic;

class Q6
{
    static void Main()
    {
        Dictionary<string, int> courses = new Dictionary<string, int>
        {
            { "CSharp", 30 },
            { "SQL", 28 },
            { "Azure", 15 }
        };

        string cancelledCourse = Console.ReadLine()!;
        // TODO: Remove key if available and print remaining courses
        if (courses.ContainsKey(cancelledCourse))
        {
            courses.Remove(cancelledCourse);
        }
        foreach (var c in courses)
        {
            Console.WriteLine($"CourseName: {c.Key} and {c.Value}");
        }
    }
}
