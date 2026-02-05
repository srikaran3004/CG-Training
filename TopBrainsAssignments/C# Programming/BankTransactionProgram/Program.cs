using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var l = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int b = l[0];
        var t = Console.ReadLine().Split().Select(int.Parse);

        foreach (int x in t)
        {
            if (x >= 0)
                b += x;
            else if (b + x >= 0)
                b += x;
        }

        Console.WriteLine(b);
    }
}
