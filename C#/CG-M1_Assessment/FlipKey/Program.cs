using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the word:");
        string str = Console.ReadLine();

        CleanseAndInverst ci = new CleanseAndInverst();
        string result = ci.calculate(str);

        Console.WriteLine(result);
    }
}