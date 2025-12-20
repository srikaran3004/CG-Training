// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount(); //Here first BankAccount acts as datatype for acc1 and next BankAccount represents obj of that class.
        acc1.AccNum = 101;
        acc1.balance = 10000;
        Employee emp1 = new Employee();
        emp1.EmpName = "Srikaran";
        emp1.salary = 80000;
        emp1.displayDetails();
    }
}
//static fields are accessed by the whole class.
class BankAccount
{
    public int AccNum;
    private double balance;
    public void Deposit(double amt)
    {
        balance += amt;
        Console.WriteLine($"Updated balance :{balance}");
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

