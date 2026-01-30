using System;
class Program
{
    public static void Main(String[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        Swap(ref a, ref b);
    }
    static void Swap(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }
}