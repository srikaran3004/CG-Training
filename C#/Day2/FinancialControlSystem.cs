using System;
class FinancialControlSystem
{
    public static void calculate()
    {
        while (true)
        {
            Console.WriteLine("Main Menu: ");
            Console.WriteLine("1. Check Loan Eligibility");
            Console.WriteLine("2. Calculate tax");
            Console.WriteLine("3. Enter Transactions");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter User Choice");
            int num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Console.WriteLine("Enter User Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter User Monthly Income: ");
                    double income = Convert.ToDouble(Console.ReadLine());
                    if (age >= 21 && income >= 30000)
                    {
                        Console.WriteLine("User Eligible");
                    }
                    else
                    {
                        Console.WriteLine("User not Eligible");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter User Annual Income: ");
                    double annualI = Convert.ToDouble(Console.ReadLine());
                    double tax = 0;
                    if (annualI <= 250000)
                    {
                        tax = 0;
                    }
                    else if (annualI > 250000 && annualI <= 500000)
                    {
                        tax = 0.05 * annualI;
                    }
                    else if (annualI > 500000 && annualI <= 1000000)
                    {
                        tax = 0.2 * annualI;
                    }
                    else
                    {
                        tax = 0.3 * annualI;
                    }
                    Console.WriteLine($"Tax calculated: Rs{tax}");
                    break;
                case 3:
                    Console.WriteLine("Enter 5 Transacations");
                    int cnt = 0;
                    while (cnt < 5)
                    {
                        Console.WriteLine("Please Enter amount: ");
                        double amt = Convert.ToDouble(Console.ReadLine());
                        if (amt < 0)
                        {
                            Console.WriteLine("Invalid Transaction");
                            continue;
                        }
                        Console.WriteLine($"Added to Curr Balance: {amt}");
                        cnt++;
                    }
                    break;
                case 4:
                    Console.WriteLine("Exiting Program");
                    return;
                default:
                    Console.WriteLine("Please enter valid choice");
                    break;
            }
        }
    }
}