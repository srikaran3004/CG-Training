using System;
class SwapNums
{
    public static void calculate()
    {
        int a=Convert.ToInt32(Console.ReadLine());
        int b=Convert.ToInt32(Console.ReadLine());
        int temp;
        temp=a;
        a=b;
        b=temp;
        Console.WriteLine($"After swap: {a} and {b}");
    }
}