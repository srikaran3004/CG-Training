using System;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        int m = t / 60;
        int s = t % 60;
        string r = m.ToString() + ":" + s.ToString("D2");
        Console.WriteLine(r);
    }
}
