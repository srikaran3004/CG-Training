using System;

class ABC
{
    public static void calculate()
    {
        int res = sum(1, 2, 3, 4, 5, 6);
        Console.WriteLine(res);
    }
    public static int sum(int b, int c, int a = 10, params int[] num)// normal parameters, default parameters, params.
    {
        int total = 0;
        foreach (int i in num)
        {
            total += i;
        }
        return total;
    }
    /**
    int[] arr = { 1, 2, 3, 4 };
    foreach (int num in arr)
    {
        Console.WriteLine(num);
    }
    string s="Sri karan";
    foreach(char ch in s)
    {
        Console.WriteLine(ch);
    }
    int[] v1 = { 1, 2, 3, 4 };
    int[] v2 = { 5, 6, 7, 8 };
    int res = sumOfNum(v1, v2);
    Console.WriteLine($"Sum :{res}");
    **/
    /**
    public static int sumOfNum(params int[] arr, params int[] arr1) //We cannot pass multiple params.
    {
        //params should be always last while passing as parameter.
        int sum = 0, sum1 = 0;
        foreach (int i in arr)
        {
            sum += i;
        }
        foreach (int i in arr1)
        {
            sum1 += i;
        }
        int sum2 = sum + sum1;
        return sum2;
    }
    **/
    /**

public static int sumOfNum(params int[] arr)
{
    int sum = 0;
    foreach (int i in arr)
    {
        sum += i;
    }
    return sum;
}
}
    public static int inc(ref int x)
    {
        x++;
        return x;
    }
    public static int inc(ref int x)
    {
        x++;
        return x;
    }

    public static void calculate()
    {
        int x = 10;
        int res = inc(ref x);
        Console.WriteLine("Result: " + res);
        Console.WriteLine("x value: " + x);
    }

    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }
**/
}
