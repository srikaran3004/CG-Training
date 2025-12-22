using System;
class RevNum
{
    public static void calculate()

    {
        int num = Convert.ToInt32(Console.ReadLine());
        int rev = 0;
        while (num > 0)
        {
            rev = rev * 10 + num % 10;
            num /= 10;
        }
        Console.WriteLine(rev);
    }
}