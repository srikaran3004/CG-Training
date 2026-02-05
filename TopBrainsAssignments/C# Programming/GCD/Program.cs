using System;
using System.Linq;

class Program
{
    static int G(int a, int b)
    {
        return b == 0 ? a : G(b, a % b);
    }

    static void Main()
    {
        var v = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = v[0];
        int b = v[1];
        Console.WriteLine(G(a, b));
    }
}
