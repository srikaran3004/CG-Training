using System;

// static fields are accessed by the whole class.
class BankAccount
{
    public int AccNum;
    private double balance;

    public void Deposit(double amt)
    {
        balance += amt;
        Console.WriteLine($"Updated balance: {balance}");
    }
}

class Employee
{
    public string EmpName = "";
    public double salary;

    public void displayDetails()
    {
        Console.WriteLine($"Employee {EmpName} earns {salary}");
    }
}

// constants can't be declared inside a constructor.
// "readonly" is used when a value is assigned only once (usually in constructor).
// Example: Aadhaar number, PAN number, Customer ID.
class Wallet
{
    private double money;

    public void addMoney(double amt)
    {
        money += amt;
    }

    public double getBalance()
    {
        return money;
    }
}
