using System;

class SaleTransaction
{
    public string InvNo;
    public string CustName;
    public string Item;
    public int Qty;
    public decimal BuyAmt;
    public decimal SellAmt;
    public string Result;
    public decimal DiffAmt;
    public decimal Margin;

    public static SaleTransaction LastTxn;
    public static bool HasTxn = false;

    public void Calc()
    {
        if (SellAmt > BuyAmt)
        {
            Result = "PROFIT";
            DiffAmt = SellAmt - BuyAmt;
        }
        else if (SellAmt < BuyAmt)
        {
            Result = "LOSS";
            DiffAmt = BuyAmt - SellAmt;
        }
        else
        {
            Result = "BREAK-EVEN";
            DiffAmt = 0;
        }

        Margin = (DiffAmt / BuyAmt) * 100;
    }

    public static void Show()
    {
        if (!HasTxn || LastTxn == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("-------------- Last Transaction --------------");
        Console.WriteLine("InvoiceNo: " + LastTxn.InvNo);
        Console.WriteLine("Customer: " + LastTxn.CustName);
        Console.WriteLine("Item: " + LastTxn.Item);
        Console.WriteLine("Quantity: " + LastTxn.Qty);
        Console.WriteLine("Purchase Amount: " + LastTxn.BuyAmt.ToString("F2"));
        Console.WriteLine("Selling Amount: " + LastTxn.SellAmt.ToString("F2"));
        Console.WriteLine("Status: " + LastTxn.Result);
        Console.WriteLine("Profit/Loss Amount: " + LastTxn.DiffAmt.ToString("F2"));
        Console.WriteLine("Profit Margin (%): " + LastTxn.Margin.ToString("F2"));
        Console.WriteLine("--------------------------------------------");
    }

    public static void ReCalc()
    {
        if (!HasTxn || LastTxn == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        LastTxn.Calc();

        Console.WriteLine("Status: " + LastTxn.Result);
        Console.WriteLine("Profit/Loss Amount: " + LastTxn.DiffAmt.ToString("F2"));
        Console.WriteLine("Profit Margin (%): " + LastTxn.Margin.ToString("F2"));
        Console.WriteLine("------------------------------------------------------");
    }
}
