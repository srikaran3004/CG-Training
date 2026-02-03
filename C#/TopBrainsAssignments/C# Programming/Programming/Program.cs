using System;

public class Calculation
{
    public static void Main()
    {
        int m = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());

        Calculation calc = new Calculation();
        int result = calc.CountLuckyNumbers(m, n);

        Console.WriteLine(result);
    }

    public int CountLuckyNumbers(int m, int n)
    {
        int count = 0;

        for (int x = m; x <= n; x++)
        {
            if (!IsPrime(x))
            {
                int sumX = DigitSum(x);
                int sumSquare = DigitSum(x * x);

                if (sumSquare == sumX * sumX)
                {
                    count++;
                }
            }
        }

        return count;
    }

    private int DigitSum(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }

    private bool IsPrime(int num)
    {
        if (num < 2) return false;

        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }
}
