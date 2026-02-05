using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] r = Console.ReadLine().Split();
        object[] v = new object[r.Length];

        for (int i = 0; i < r.Length; i++)
        {
            if (int.TryParse(r[i], out int n))
                v[i] = n;
            else if (bool.TryParse(r[i], out bool b))
                v[i] = b;
            else if (r[i].ToLower() == "null")
                v[i] = null;
            else
                v[i] = r[i];
        }

        int s = 0;

        foreach (object o in v)
            if (o is int n)
                s += n;

        Console.WriteLine(s);
    }
}
