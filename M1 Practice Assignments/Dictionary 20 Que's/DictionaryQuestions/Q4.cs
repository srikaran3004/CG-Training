using System;
using System.Collections.Generic;

class Q4
{
    static void Main()
    {
        string[] attempts = { "raj", "kavi", "raj", "raj", "kavi" };
        Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
        // TODO: Count attempts and print users with attempts >= 3
        foreach(var s in attempts)
        {
            if (failedAttempts.ContainsKey(s))
            {
                failedAttempts[s]++;
            }
            else
            {
                failedAttempts.Add(s,1);
            }
        }
        Console.WriteLine("Failed Attempts >=3 are:");
        foreach(var d in failedAttempts)
        {
            if(d.Value >= 3)
            {
                Console.WriteLine($"{d.Key}");
            }
        }
    }
}
