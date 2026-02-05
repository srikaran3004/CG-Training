using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int sum = 0;

        foreach (int n in nums)
        {
            if (n == 0) break;
            if (n < 0) continue;
            sum += n;
        }

        Console.WriteLine(sum);
    }
}
