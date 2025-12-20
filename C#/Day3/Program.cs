// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        /**
        Wallet w1 = new Wallet();
        w1.addMoney(5000);

        Console.WriteLine($"Available amount: {w1.getBalance()}");

        Employee emp1 = new Employee();
        emp1.EmpName = "Srikaran";
        emp1.salary = 80000;
        emp1.displayDetails();

        BankAccount acc1 = new BankAccount();
        acc1.AccNum = 101;
        acc1.Deposit(10000);
        **/
        int sum1 = MathOps.add(10, 20);
        double sum2 = MathOps.add(10.5, 20.3);
        int sum3 = MathOps.add(1, 2, 3);

        Console.WriteLine($"Sum of 2 ints: {sum1}");
        Console.WriteLine($"Sum of 2 doubles: {sum2}");
        Console.WriteLine($"Sum of 3 ints: {sum3}");
    }
}
