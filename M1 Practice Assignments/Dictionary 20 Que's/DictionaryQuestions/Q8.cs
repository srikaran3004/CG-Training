using System;
using System.Collections.Generic;

class Q8
{
    static void Main()
    {
        Dictionary<string, int> temperature = new Dictionary<string, int>
        {
            { "Chennai", 38 },
            { "Delhi", 41 },
            { "Bengaluru", 29 }
        };

        // TODO: Iterate and find max temperature city
        var maxi= temperature.Max(t=>t.Value);
        var name=temperature.Where(t=>t.Value == maxi).Select(t=>t.Key);
        Console.WriteLine($"Hottest City: {name} with temp: {maxi}");
    }
}
