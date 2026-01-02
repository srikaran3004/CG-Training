using System;
using TechDomain;

class Program
{
    static void Main()
    {
        LogRegex r = new LogRegex();

        Console.WriteLine(r.Task1("[INFO] 2025-03-21T14:22:19Z"));

        var m2 = r.Task2("service=auth userId=USR_1023");
        Console.WriteLine(m2.Groups["service"].Value);
        Console.WriteLine(m2.Groups["userId"].Value);

        Console.WriteLine(r.Task3("passwordTemp123"));

        var m4 = r.Task4("txnId=TXN998877 amount=₹45,000.50");
        Console.WriteLine(m4.Groups["txnId"].Value);
        Console.WriteLine(m4.Groups["amount"].Value);

        Console.WriteLine(r.Task5("password=abc123"));
    }
}
