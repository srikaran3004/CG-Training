using System;

class Program
{
    static double FeetToCentimeters(int feet)
    {
        double cm = feet * 30.48;
        return Math.Round(cm, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int ft = int.Parse(Console.ReadLine());
        double res = FeetToCentimeters(ft);
        Console.WriteLine(res);
    }
}
