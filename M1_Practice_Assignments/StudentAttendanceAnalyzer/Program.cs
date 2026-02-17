using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "101:Present,102:Absent,103:Present,104:,105:Present,ABC:Present,106:Absent";
        Dictionary<int, bool?> attendance = new Dictionary<int, bool?>();
        string[] entries = input.Split(',');
        foreach (string entry in entries)
        {
            string[] parts = entry.Split(':');
            int id;
            if (int.TryParse(parts[0], out id))
            {
                if (parts.Length > 1)
                {
                    if (parts[1] == "Present")
                        attendance[id] = true;
                    else if (parts[1] == "Absent")
                        attendance[id] = false;
                    else
                        attendance[id] = null;
                }
                else
                {
                    attendance[id] = null;
                }
            }
        }
        int present = 0;
        int absent = 0;
        int notMarked = 0;
        StringBuilder report = new StringBuilder();
        report.AppendLine("Attendance Report");
        report.AppendLine("-----------------");
        foreach (var item in attendance)
        {
            if (item.Value == true)
            {
                report.AppendLine(item.Key + " -> Present");
                present++;
            }
            else if (item.Value == false)
            {
                report.AppendLine(item.Key + " -> Absent");
                absent++;
            }
            else
            {
                report.AppendLine(item.Key + " -> Not Marked");
                notMarked++;
            }
        }
        report.AppendLine();
        report.AppendLine("Total Present: " + present);
        report.AppendLine("Total Absent: " + absent);
        report.AppendLine("Not Marked: " + notMarked);

        Console.WriteLine(report.ToString());
    }
}
