using System;
using System.Collections.Generic;
using BALCalculator;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BalCalc obj = new BalCalc();

            List<string> result = obj.ReverseNames();

            Console.WriteLine("Reversed Names:\n");

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
