using System;

class MultiplicationTable
{
    public static void calculate()
    {
        Console.WriteLine("Enter the from range: ");
        int from = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the to range: ");
        int to = Convert.ToInt32(Console.ReadLine());
        for (int i = from; i <= to; i++)
        {
            Console.WriteLine($"Table of {i}:");
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i} X {j} = {i * j}");
            }
            Console.WriteLine();
        }
    }
}
