using System;
using System.Collections.Generic;

class Q1
{
    static void Main()
    {
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            { "P101", 25 },
            { "P102", 0 },
            { "P103", 14 }
        };

        string inputCode = Console.ReadLine()!;
        // TODO: Implement lookup and print result
        if (inventory.ContainsKey(inputCode))
        {
            Console.WriteLine(inventory[inputCode]);
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }
}