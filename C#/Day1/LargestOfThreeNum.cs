using System;
class LargestOfThreeNum
{
    public static void calculate()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        if (a >b && a >c)
        {
            Console.WriteLine($"Greatest Num is: {a}");
        }
        else if (b >c)
        {
            Console.WriteLine($"Greatest Num is: {b}");
        }
        else
        {
            Console.WriteLine($"Greatest Num is: {c}");
        }
    }
}