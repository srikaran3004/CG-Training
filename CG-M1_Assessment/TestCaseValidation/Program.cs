using System;

public class Program
{
    public double Balance { get; private set; }

    public Program(double initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount < 0)
        {
            throw new Exception("Deposit amount cannot be negative");
        }

        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            throw new Exception("Insufficient funds.");
        }

        Balance -= amount;
    }

    public static void Main()
    {
        try
        {
            Program account = new Program(1000);

            Console.WriteLine("Initial Balance: " + account.Balance);

            account.Deposit(500);
            Console.WriteLine("After Deposit: " + account.Balance);

            account.Withdraw(300);
            Console.WriteLine("After Withdrawal: " + account.Balance);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
