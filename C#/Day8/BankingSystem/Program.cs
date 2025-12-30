using System;
using BankingSystem;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(accountNumber, balance);

            Console.Write("Enter Withdrawal Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            account.Withdraw(amount);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (BankOperationException ex)
        {
            Console.WriteLine(ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Reason: " + ex.InnerException.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }
}
