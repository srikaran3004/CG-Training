using System;
class FeetToCenti
{
    public static void calculate()
    {
        double foot = 30.48;
        Console.WriteLine("Enter feet: ");
        double ft=Convert.ToDouble(Console.ReadLine());
        double cm=ft*foot;
        Console.WriteLine($"Value from ft to cm: {cm}");
    }
}