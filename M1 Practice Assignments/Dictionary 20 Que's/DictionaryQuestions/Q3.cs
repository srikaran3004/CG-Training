using System;
using System.Collections.Generic;

class Q3
{
    static void Main()
    {
        int[] employeeIds = { 1001, 1002, 1001, 1003, 1002, 1001 };
        Dictionary<int, int> attendance = new Dictionary<int, int>();
        // TODO: Build frequency map and print
        foreach(var i in employeeIds)
        {
            if (attendance.ContainsKey(i))
            {
                attendance[i]++;
            }
            else
            {
                attendance.Add(i,1);
            }
        }
        foreach(var d in attendance)
        {
            Console.WriteLine($"Attendance of {d.Key} is {d.Value}");
        }
    }
}
