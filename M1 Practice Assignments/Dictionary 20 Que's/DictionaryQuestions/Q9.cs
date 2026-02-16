using System;
using System.Collections.Generic;

class Q9
{
    static void Main()
    {
        string text = Console.ReadLine();
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        // TODO: Build frequency and display sorted output
        foreach (char c in text)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount.Add(c, 1);
            }
        }

        var sortedKeys = new List<char>(charCount.Keys);
        sortedKeys.Sort();

        foreach (char key in sortedKeys)
        {
            Console.WriteLine(key + " : " + charCount[key]);
        }
        var res=charCount.GroupBy(c=>c).OrderBy(t=>t.Key);
    }
}
