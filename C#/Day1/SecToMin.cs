using System;
class SecToMin
{
    public static void calculate()
    {
        int sec=Convert.ToInt32(Console.ReadLine());
        int min=sec/60;
        Console.WriteLine($"Sec to Min: {min}");
    }
}