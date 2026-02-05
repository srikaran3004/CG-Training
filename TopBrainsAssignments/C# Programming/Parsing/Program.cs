using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] t = Console.ReadLine().Split();
        int s = 0;

        foreach (string v in t)
        {
            if (int.TryParse(v, out int n))
                s += n;
        }

        Console.WriteLine(s);
    }
}
