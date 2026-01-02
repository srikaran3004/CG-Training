using System;
using LogProcessing;

class Program
{
    static void Main()
    {
        LogParser p = new LogParser();

        Console.WriteLine(p.IsValidLine("[INF] Test"));

        string[] a = p.SplitLogLine("a<***>b<====>c");
        foreach (string x in a)
            Console.WriteLine(x);

        Console.WriteLine(p.CountQuotedPasswords("\"password1\" \"passWORD2\""));

        Console.WriteLine(p.RemoveEndOfLineText("error end-of-line9"));

        string[] l =
        {
            "User password123 failed",
            "System running"
        };

        string[] o = p.ListLinesWithPasswords(l);
        foreach (string x in o)
            Console.WriteLine(x);
    }
}
