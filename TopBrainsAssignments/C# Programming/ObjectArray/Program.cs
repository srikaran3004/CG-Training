using System;

class Program
{
    static void Main()
    {
        object[] values = { 1, "hello", 5, true, null, 10, 3.14, false, -2 };

        int sum = SumIntegers(values);

        Console.WriteLine($"Sum of integers: {sum}");
    }

    public static int SumIntegers(object[] values)
    {
        int sum = 0;

        foreach (var v in values)
        {
            if (v is int x)
            {
                sum += x;
            }
        }

        return sum;
    }
}
