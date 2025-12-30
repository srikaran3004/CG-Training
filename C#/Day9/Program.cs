using System;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
        // --------------------------------------------------
        // \d → checks if string contains at least one digit
        // --------------------------------------------------

        // string s = "abc123";
        // bool res = Regex.IsMatch(s, @"\d");
        // Console.WriteLine(res);
        // Output: True


        // --------------------------------------------------
        // \d → matches any single digit
        // --------------------------------------------------

        // string s = "123_123";
        // string pattern = @"\d";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 1 2 3 1 2 3


        // --------------------------------------------------
        // \d+ → matches one or more digits together
        // --------------------------------------------------

        // string s = "Amount:5000";
        // string pattern = @"\d+";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: 5000


        // --------------------------------------------------
        // Named Capturing Group → (?<groupname>pattern)
        // --------------------------------------------------
        // Extract value using group name

        // string sentence = "Amount:5000";
        // string pattern = @"Amount:(?<value>\d+)";
        // Match m = Regex.Match(sentence, pattern);
        // Console.WriteLine(m.Groups["value"].Value);
        // Output: 5000


        // --------------------------------------------------
        // Named groups with Regex.Matches (year, month, date)
        // --------------------------------------------------

        // string input = "1992-02-23 2025-12-29";
        // string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";

        // MatchCollection matches = Regex.Matches(input, pattern);

        // foreach (Match match in matches)
        // {
        //     Console.Write(
        //         match.Groups["year"].Value + "-" +
        //         match.Groups["month"].Value + "-" +
        //         match.Groups["date"].Value + " "
        //     );
        // }
        // Output: 1992-02-23 2025-12-29


        // --------------------------------------------------
        // Access only one named group
        // --------------------------------------------------

        // Console.WriteLine(m.Groups["year"].Value);
        // Output: 1992

        // --------------------------------------------------
        // Numbered capturing groups using Regex.Match
        // --------------------------------------------------
        // Groups[0] → entire match
        // Groups[1] → year
        // Groups[2] → month
        // Groups[3] → date

        // string input = "Date: 2025-12-29";
        // string pattern = @"(\d{4})-(\d{2})-(\d{2})";

        // Match m = Regex.Match(input, pattern);

        // Console.WriteLine(
        //     m.Groups[0].Value + " " +
        //     m.Groups[1].Value + " " +
        //     m.Groups[2].Value + " " +
        //     m.Groups[3].Value
        // );
        // Output: 2025-12-29 2025 12 29

        // string ip = "a !..le"; //(.) -> means any character is allowed.
        // string p1 = @"a..";
        // string p2 = @"a...e";
        // Match m = Regex.Match(ip, p1);
        // Console.WriteLine(m.Value);
        // Match m1 = Regex.Match(ip, p2);
        // Console.WriteLine(m1.Value);


        List<string> Emails = new List<string>
        {
            "john.doe@gmail.com",
            "alice_123@yahoo.in",
            "mark.smith@company.com",
            "support-abc@banking.co.in",
            "user.nametag@domain.org",

            "john.doe@gmail",
            "alice@@yahoo.com",
            "mark.smith@.com",
            "support@banking..com",
            "user name@gmail.com",
            "@domain.com",
            "admin@domain",
            "info@domain,com",
            "finance#dept@corp.com",
            "plainaddress"
        };
        string pattern = @"\b[\w.-]+@[\w.-]+\.\w{2,}\b";
        foreach (string email in Emails)
        {
            if (Regex.IsMatch(email, pattern))
            {
                Console.WriteLine(email);
            }
        }
    }
}
