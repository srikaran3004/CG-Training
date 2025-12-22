using System;

class Account
{
    private int number;
    private double amount;

    public static string Name = "ABC National Bank";

    public Account(int num, double initialAmount)
    {
        number = num;
        amount = initialAmount;
    }

    public void Add(double sum)
    {
        if (sum > 0)
        {
            amount += sum;
            Console.WriteLine("Amount added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid add amount.");
        }
    }

    public void Add(ref double sum)
    {
        if (sum > 0)
        {
            amount += sum;
            sum = 0;
            Console.WriteLine("Amount added using ref.");
        }
    }

    public bool Remove(double sum, out string note)
    {
        if (sum <= 0)
        {
            note = "Invalid remove amount.";
            return false;
        }

        if (sum > amount)
        {
            note = "Insufficient amount.";
            return false;
        }

        amount -= sum;
        note = "Removal successful.";
        return true;
    }

    public void Show()
    {
        Console.WriteLine("---------------");
        Console.WriteLine($"Bank Name  : {Name}");
        Console.WriteLine($"Account No : {number}");
        Console.WriteLine($"Amount     : ₹{amount}");
        Console.WriteLine("---------------");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Banking System");

        Console.Write("Enter Account Number: ");
        int num;
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("Invalid input. Enter valid Account Number: ");
        }

        Console.Write("Enter Initial Amount: ");
        double initialAmount;
        while (!double.TryParse(Console.ReadLine(), out initialAmount))
        {
            Console.Write("Invalid input. Enter valid Amount: ");
        }

        Account account = new Account(num, initialAmount);

        int option;
        do
        {
            Console.WriteLine("\n1. Add");
            Console.WriteLine("2. Remove");
            Console.WriteLine("3. Show Account");
            Console.WriteLine("4. Exit");
            Console.Write("Choose option: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                    Console.Write("Enter add amount: ");
                    double addAmount;
                    if (double.TryParse(Console.ReadLine(), out addAmount))
                    {
                        account.Add(addAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case 2:
                    Console.Write("Enter remove amount: ");
                    double removeAmount;
                    if (double.TryParse(Console.ReadLine(), out removeAmount))
                    {
                        if (account.Remove(removeAmount, out string note))
                        {
                            Console.WriteLine(note);
                        }
                        else
                        {
                            Console.WriteLine(note);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount.");
                    }
                    break;

                case 3:
                    account.Show();
                    break;

                case 4:
                    Console.WriteLine("Thank you for banking with us!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

        } while (option != 4);
    }
}
