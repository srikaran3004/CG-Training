using System;
using System.Collections.Generic;

class Q10
{
    static void Main()
    {
        Dictionary<int, string> branch1 = new Dictionary<int, string>
        {
            { 101, "Anu" },
            { 102, "Dev" }
        };

        Dictionary<int, string> branch2 = new Dictionary<int, string>
        {
            { 102, "Devika" },
            { 103, "Rahul" }
        };

        // TODO: Merge dictionaries and print final result
        foreach (var b in branch2)
        {
            branch1[b.Key] = b.Value;
        }
        foreach (var item in branch1)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
