using System;
class EvenOdd
{
    public static void calculate()
    {
        int num=Convert.ToInt32(Console.ReadLine());
        if (num % 2 == 0)
        {
            Console.WriteLine("Num is even");
        }
        else
        {
            Console.WriteLine("Num is Odd");
        }
    }
}