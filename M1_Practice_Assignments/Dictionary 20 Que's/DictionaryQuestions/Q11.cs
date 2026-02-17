using System;
using System.Collections.Generic;

class Q11
{
    static void Main()
    {
        Dictionary<string, string> meanings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        // TODO: Add words and demonstrate case-insensitive retrieval
        meanings.Add("Srikaran", "Student");
        meanings.Add("Pavan", "Traniee");
        Console.WriteLine(meanings["srikaran"]);
        Console.WriteLine(meanings["pavan"]);
    }
}
