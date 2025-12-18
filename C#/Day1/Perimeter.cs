using System;
class Perimeter
{
    public static void calculate()
    {
        double r=Convert.ToDouble(Console.ReadLine());
        double peri=2*Math.PI*r;
        Console.WriteLine($"Perimeter of Circle :{peri}");
    }
}