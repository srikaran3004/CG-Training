using System;

class CalculationHelper
{
    public static int CalculateStayDays(int days)
    {
        if (days <= 0)
            return 0;

        return 1 + CalculateStayDays(days - 1);
    }
}

class InputHelper
{
    public static int ReadAge(string input)
    {
        int age;
        int.TryParse(input, out age);
        return age;
    }
}

class HospitalSystemInit
{
    public const string HospitalName = "City Care Hospital";

    static HospitalSystemInit()
    {
        Console.WriteLine("Hospital system booting...");
    }
}
