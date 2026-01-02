using System.Text.RegularExpressions;

namespace LogProcessing
{
    public class LogParser
    {
        private readonly string validLineRegexPattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
        private readonly string splitLineRegexPattern = @"<\*{3}>|<={4}>|<\^\*>";
        private readonly string quotedPasswordRegexPattern = "\"[^\"]*password[^\"]*\"";
        private readonly string endOfLineRegexPattern = @"end-of-line\d+";
        private readonly string weakPasswordRegexPattern = @"password[a-zA-Z0-9]+";

        public bool IsValidLine(string t)
        {
            return Regex.IsMatch(t, validLineRegexPattern);
        }

        public string[] SplitLogLine(string t)
        {
            return Regex.Split(t, splitLineRegexPattern);
        }

        public int CountQuotedPasswords(string t)
        {
            return Regex.Matches(t, quotedPasswordRegexPattern, RegexOptions.IgnoreCase).Count;
        }

        public string RemoveEndOfLineText(string t)
        {
            return Regex.Replace(t, endOfLineRegexPattern, "");
        }

        public string[] ListLinesWithPasswords(string[] t)
        {
            string[] r = new string[t.Length];

            for (int i = 0; i < t.Length; i++)
            {
                Match m = Regex.Match(t[i], weakPasswordRegexPattern, RegexOptions.IgnoreCase);

                if (m.Success)
                    r[i] = m.Value + ": " + t[i];
                else
                    r[i] = ": " + t[i];
            }

            return r;
        }
    }
}
