using System;

class Program
{
    static void Main()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int opt;
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Invalid option.");
                continue;
            }

            switch (opt)
            {
                case 1:
                    NewTxn();
                    break;
                case 2:
                    SaleTransaction.Show();
                    break;
                case 3:
                    SaleTransaction.ReCalc();
                    break;
                case 4:
                    run = false;
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;
                default:
                    Console.WriteLine("Invalid menu option.");
                    break;
            }
        }
    }

    static void NewTxn()
    {
        SaleTransaction t = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        t.InvNo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(t.InvNo))
        {
            Console.WriteLine("Invoice No cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        t.CustName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        t.Item = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out t.Qty) || t.Qty <= 0)
        {
            Console.WriteLine("Quantity must be greater than 0.");
            return;
        }

        Console.Write("Enter Purchase Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out t.BuyAmt) || t.BuyAmt <= 0)
        {
            Console.WriteLine("Purchase amount must be greater than 0.");
            return;
        }

        Console.Write("Enter Selling Amount (total): ");
        if (!decimal.TryParse(Console.ReadLine(), out t.SellAmt) || t.SellAmt < 0)
        {
            Console.WriteLine("Selling amount must be 0 or more.");
            return;
        }

        t.Calc();

        SaleTransaction.LastTxn = t;
        SaleTransaction.HasTxn = true;

        Console.WriteLine();
        Console.WriteLine("Transaction saved successfully.");
        Console.WriteLine("Status: " + t.Result);
        Console.WriteLine("Profit/Loss Amount: " + t.DiffAmt.ToString("F2"));
        Console.WriteLine("Profit/Loss Margin (%): " + t.Margin.ToString("F2"));
        Console.WriteLine("------------------------------------------------------");
    }
}
