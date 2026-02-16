using System;
using System.Collections.Generic;

class Q7
{
    static void Main()
    {
        Dictionary<string, decimal> catalog = new Dictionary<string, decimal>
        {
            { "Pen", 12.5m },
            { "Book", 90m },
            { "Bag", 450m }
        };

        string item = Console.ReadLine()!;
        // TODO: Print item price if exists; else print "Invalid Item"
        if (catalog.ContainsKey(item))
        {
            Console.WriteLine(catalog[item]);
        }
        else
        {
            Console.WriteLine("Invalid Item");
        }
    }
}
