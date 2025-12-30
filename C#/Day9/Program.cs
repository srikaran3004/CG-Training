using System;
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
        // \d* → matches zero or more digits
        // --------------------------------------------------

        // string s = "Amount:5000";
        // string pattern = @"\d*";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: (empty string)


        // --------------------------------------------------
        // Extract all numbers using \d+
        // --------------------------------------------------

        // string s = "10_20_30";
        // string pattern = @"\d+";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 10 20 30


        // --------------------------------------------------
        // \D → non-digit characters
        // --------------------------------------------------

        // string s = "10a20b30";
        // string pattern = @"\D";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: a b


        // --------------------------------------------------
        // First non-digit using \D
        // --------------------------------------------------

        // string s = "10a20b30";
        // string pattern = @"\D";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: a


        // --------------------------------------------------
        // \w → word characters (letters, digits, underscore)
        // --------------------------------------------------

        // string s = "10a20b30";
        // string pattern = @"\w";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: 1


        // --------------------------------------------------
        // All word characters using \w
        // --------------------------------------------------

        // string s = "10a20b30";
        // string pattern = @"\w";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 1 0 a 2 0 b 3 0


        // --------------------------------------------------
        // \w ignores special characters
        // --------------------------------------------------

        // string s = "10a20b30@!";
        // string pattern = @"\w";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 1 0 a 2 0 b 3 0


        // --------------------------------------------------
        // \w includes underscore
        // --------------------------------------------------

        // string s = "10a20b30@!_abc";
        // string pattern = @"\w";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 1 0 a 2 0 b 3 0 _ a b c


        // --------------------------------------------------
        // \W → non-word characters
        // --------------------------------------------------

        // string s = "10a20b30@!_abc";
        // string pattern = @"\W";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: @ !


        // --------------------------------------------------
        // \W includes space
        // --------------------------------------------------

        // string s = "10a20b30@!_abc ";
        // string pattern = @"\W";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: @ ! (space)


        // --------------------------------------------------
        // First non-word character
        // --------------------------------------------------

        // string s = "10a20b30@!_abc ";
        // string pattern = @"\W";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: @


        // --------------------------------------------------
        // \s → whitespace (space, tab, newline)
        // --------------------------------------------------

        // string s = "10a20b30@!_abc !01\t";
        // string pattern = @"\s";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: (space) (tab)


        // --------------------------------------------------
        // \S → non-whitespace characters
        // --------------------------------------------------

        // string s = "10a20b30@!_abc !01\t";
        // string pattern = @"\S";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: 1 0 a 2 0 b 3 0 @ ! _ a b c ! 0 1


        // --------------------------------------------------
        // Custom character class → non-alphanumeric
        // --------------------------------------------------

        // string s = "10a20b30@!_abc !01\t file.txt";
        // string pattern = @"[^a-zA-Z0-9]";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: @ ! _ (space) ! (tab) (space) .


        // --------------------------------------------------
        // ^ and $ → start and end of string
        // --------------------------------------------------

        // string s = "lo10a20b30@!_ab?c !01\t ?file.txt Hello";
        // string pattern = @"^lo+\d+lo$";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: (no match)


        // --------------------------------------------------
        // {n} → exact number of repetitions
        // --------------------------------------------------

        // Match m = Regex.Match("Date: 2025-12-29", @"\d{4}-\d{2}-\d{2}");
        // Console.WriteLine(m.Value);
        // Output: 2025-12-29


        // --------------------------------------------------
        // | → OR operator
        // --------------------------------------------------

        // string s = "cat dog";
        // string pattern = @"cat|dog";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: cat dog


        // --------------------------------------------------
        // . → matches any single character
        // --------------------------------------------------

        // string s = "abc";
        // string pattern = @".";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: a b c


        // --------------------------------------------------
        // .* → matches everything
        // --------------------------------------------------

        // string s = "Hello World";
        // string pattern = @".*";
        // Match m = Regex.Match(s, pattern);
        // Console.WriteLine(m.Value);
        // Output: Hello World


        // --------------------------------------------------
        // \b → word boundary
        // --------------------------------------------------

        // string s = "cat scatter category";
        // string pattern = @"\bcat\b";
        // MatchCollection matches = Regex.Matches(s, pattern);
        // foreach (Match match in matches)
        // {
        //     Console.Write(match.Value + " ");
        // }
        // Output: cat
    }
}
