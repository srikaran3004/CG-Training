using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var inp = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = inp[0];
        int u = inp[1];
        int[] row = new int[u];

        for (int i = 0; i < u; i++)
            row[i] = n * (i + 1);

        Console.WriteLine(string.Join(" ", row));
    }
}
