using System;

class Program
{
    static string HgtCat(int hcm)
    {
        if (hcm < 150)
            return "Short";
        else if (hcm < 180)
            return "Average";
        else
            return "Tall";
    }

    public static void Main()
    {
        int hcm = int.Parse(Console.ReadLine());
        Console.WriteLine(HgtCat(hcm));
    }
}
