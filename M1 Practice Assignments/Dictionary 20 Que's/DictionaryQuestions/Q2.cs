using System;
using System.Collections.Generic;

class Q2
{
    static void Main()
    {
        Dictionary<string, int> marks = new Dictionary<string, int>
        {
            { "Asha", 78 },
            { "Bala", 82 }
        };

        string student = Console.ReadLine()!;
        int newMark = Convert.ToInt32(Console.ReadLine()); 
        // TODO: Add or update mark
        if (marks.ContainsKey(student))
        {
            marks[student] = newMark;
        }
        else
        {
            marks.Add(student, newMark);
        }
        foreach (var m in marks)
        {
            Console.WriteLine($"Student Name: {m.Key}, Marks: {m.Value}");
        }
    }
}
