using System;

class Program
{
    public static void Main(String[] args)
    {
        double r = Double.Parse(Console.ReadLine());
        double area = Math.PI * r * r;
        Console.WriteLine($"{area:F2}");
    }
}
