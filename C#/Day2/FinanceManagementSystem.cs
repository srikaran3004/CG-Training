using System;

class Debit
{
    public void atmLimit()
    {
        int limit = 40000;
        Console.Write("Enter withdrawal amount: ");
        int amt = int.Parse(Console.ReadLine());

        if (amt <= limit)
            Console.WriteLine("Withdrawal permitted within daily limit.");
        else
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
    }

    public void emiCheck()
    {
        Console.Write("Enter monthly income: ");
        double inc = double.Parse(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        double emi = double.Parse(Console.ReadLine());

        if (emi <= inc * 0.40)
            Console.WriteLine("EMI is financially manageable.");
        else
            Console.WriteLine("EMI exceeds safe income limit.");
    }

    public void dailySpend()
    {
        Console.Write("Enter number of transactions: ");
        int cnt = int.Parse(Console.ReadLine());

        double total = 0;
        for (int i = 1; i <= cnt; i++)
        {
            Console.Write("Enter amount: ");
            double amt = double.Parse(Console.ReadLine());
            total += amt;
        }

        Console.WriteLine("Total debit amount for the day: " + total);
    }

    public void minBalCheck()
    {
        Console.Write("Enter current balance: ");
        double bal = double.Parse(Console.ReadLine());

        if (bal < 2000)
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        else
            Console.WriteLine("Minimum balance requirement satisfied.");
    }
}

class Credit
{
    public void netSalary()
    {
        Console.Write("Enter gross salary: ");
        double sal = double.Parse(Console.ReadLine());

        double net = sal - (sal * 0.10);
        Console.WriteLine("Net salary credited: " + net);
    }

    public void fdMaturity()
    {
        Console.Write("Enter principal amount: ");
        double p = double.Parse(Console.ReadLine());

        Console.Write("Enter rate of interest: ");
        double r = double.Parse(Console.ReadLine());

        Console.Write("Enter time period: ");
        double t = double.Parse(Console.ReadLine());

        double si = (p * r * t) / 100;
        double mat = p + si;

        Console.WriteLine("Fixed Deposit maturity amount: " + mat);
    }

    public void rewardPoints()
    {
        Console.Write("Enter credit card spending: ");
        double amt = double.Parse(Console.ReadLine());

        int pts = (int)(amt / 100);
        Console.WriteLine("Reward points earned: " + pts);
    }

    public void bonusCheck()
    {
        Console.Write("Enter annual salary: ");
        double sal = double.Parse(Console.ReadLine());

        Console.Write("Enter years of service: ");
        int yrs = int.Parse(Console.ReadLine());

        if (sal >= 500000 && yrs >= 3)
            Console.WriteLine("Employee is eligible for bonus.");
        else
            Console.WriteLine("Employee is not eligible for bonus.");
    }
}

class FinanceManagementSystem
{
    public static void calculate()
    {
        Debit d = new Debit();
        Credit c = new Credit();
        int ch;

        do
        {
            Console.WriteLine("\n1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("1. ATM Withdrawal");
                    Console.WriteLine("2. EMI Check");
                    Console.WriteLine("3. Daily Spending");
                    Console.WriteLine("4. Minimum Balance");
                    Console.Write("Enter choice: ");
                    int dch = int.Parse(Console.ReadLine());

                    switch (dch)
                    {
                        case 1: d.atmLimit(); break;
                        case 2: d.emiCheck(); break;
                        case 3: d.dailySpend(); break;
                        case 4: d.minBalCheck(); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                    break;

                case 2:
                    Console.WriteLine("1. Net Salary");
                    Console.WriteLine("2. FD Maturity");
                    Console.WriteLine("3. Reward Points");
                    Console.WriteLine("4. Bonus Check");
                    Console.Write("Enter choice: ");
                    int cch = int.Parse(Console.ReadLine());

                    switch (cch)
                    {
                        case 1: c.netSalary(); break;
                        case 2: c.fdMaturity(); break;
                        case 3: c.rewardPoints(); break;
                        case 4: c.bonusCheck(); break;
                        default: Console.WriteLine("Invalid choice"); break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting program");
                    break;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        } while (ch != 3);
    }
}
