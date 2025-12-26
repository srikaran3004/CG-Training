using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        PayrollManager manager = new PayrollManager();
        bool run = true;
        while (run)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\nEnter your choice:");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                    int type = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Employee Name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter Hourly Rate:");
                    double rate = double.Parse(Console.ReadLine());

                    double[] hours = new double[4];
                    Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        hours[i] = double.Parse(Console.ReadLine());
                    }
                    if (type == 1)
                    {
                        Console.WriteLine("Enter Monthly Bonus:");
                        double bonus = double.Parse(Console.ReadLine());

                        FullTimeEmployee fte = new FullTimeEmployee();
                        fte.EmployeeName = name;
                        fte.HourlyRate = rate;
                        fte.MonthlyBonus = bonus;
                        fte.WeeklyHours = hours;

                        manager.RegisterEmployee(fte);
                    }
                    else
                    {
                        ContractEmployee ce = new ContractEmployee();
                        ce.EmployeeName = name;
                        ce.HourlyRate = rate;
                        ce.WeeklyHours = hours;

                        manager.RegisterEmployee(ce);
                    }
                    Console.WriteLine("Employee registered successfully\n");
                    break;
                case 2:
                    Console.WriteLine("Enter hours threshold:");
                    double threshold = double.Parse(Console.ReadLine());
                    Dictionary<string, int> overtime =
                        manager.GetOvertimeWeekCounts(PayrollManager.PayrollBoard, threshold);
                    if (overtime.Count == 0)
                    {
                        Console.WriteLine("No overtime recorded this month\n");
                    }
                    else
                    {
                        foreach (var item in overtime)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    double avg = manager.CalculateAverageMonthlypay();
                    Console.WriteLine("Overall average monthly pay: " + avg + "\n");
                    break;
                case 4:
                    Console.WriteLine("Logging off — Payroll processed successfully!");
                    run = false;
                    break;
            }
        }
    }
}
