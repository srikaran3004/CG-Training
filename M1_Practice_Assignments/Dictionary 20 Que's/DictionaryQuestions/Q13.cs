using System;
using System.Collections.Generic;

class Q13
{
    static void Main()
    {
        Dictionary<string, double> budget = new Dictionary<string, double>
        {
            { "IT", 12.5 },
            { "HR", 6.2 },
            { "Finance", 9.1 }
        };

        // TODO: Calculate and print total budget
        double total = 0;
        foreach (var d in budget)
        {
            total += d.Value;
        }
        Console.WriteLine(total);
    }
}
