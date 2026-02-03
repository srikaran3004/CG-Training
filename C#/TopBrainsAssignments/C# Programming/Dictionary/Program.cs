using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        int[] ids = { 1, 4, 5 };

        Dictionary<int, float> d = new Dictionary<int, float>()
        {
            {1, 20000},
            {4, 40000},
            {5, 15000}
        };

        Console.WriteLine(d.Values.Sum());
    }
}
