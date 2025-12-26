using System.Collections.Generic;
using System;
public abstract class EmployeeRecord
{
    public string EmployeeName { get; set; }="";
    public double[] WeeklyHours { get; set; } = new double[4];
    public abstract double GetMonthlyPay();
}
class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public double MonthlyBonus { get; set; }
    public override double GetMonthlyPay()
    {
        double sum = 0;
        for (int i = 0; i < WeeklyHours.Length; i++)
        {
            sum += WeeklyHours[i];
        }
        return (sum * HourlyRate) + MonthlyBonus;
    }
}
public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public override double GetMonthlyPay()
    {
        double sum = 0;
        for (int i = 0; i < WeeklyHours.Length; i++)
        {
            sum += WeeklyHours[i];
        }
        return (sum * HourlyRate);
    }
}

public class PayrollManager
{
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();
    public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }
    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> overtime = new Dictionary<string, int>();
        foreach (EmployeeRecord e in records)
        {
            double cnt = 0;
            foreach (double hrs in e.WeeklyHours)
            {
                if (hrs >= hoursThreshold)
                {
                    cnt+=hrs-hoursThreshold;
                }
            }
            if (cnt > 0)
            {
                overtime.Add(e.EmployeeName, (int)cnt);
            }
        }
        return overtime;
    }
    public double CalculateAverageMonthlypay()
    {
        if(PayrollBoard.Count==0) return 0;
        double amp=0;
        foreach(EmployeeRecord e in PayrollBoard)
        {
            amp+=e.GetMonthlyPay();
        }
        return amp/PayrollBoard.Count;
    }
}

