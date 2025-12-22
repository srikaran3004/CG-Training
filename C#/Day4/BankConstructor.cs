using System;

class BankAccount
{
    double balance;
    string accountNumber;

    public BankAccount(double balance, string accountNumber)
    {
        this.balance = balance;
        this.accountNumber = accountNumber;
    }

    public void ShowAccount()
    {
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Balance: " + balance);
    }
}

class FixedDeposit : BankAccount
{
    int time;
    double roi;

    public FixedDeposit(double balance, string accountNumber, int time, double roi)
        : base(balance, accountNumber)
    {
        this.time = time;
        this.roi = roi;
    }

    public void ShowFD()
    {
        base.ShowAccount();
        Console.WriteLine("Time (years): " + time);
        Console.WriteLine("Rate of Interest: " + roi);
    }
}
