using System;
using System.Collections.Generic;

class Q12
{
    static void Main()
    {
        string[] priorities = { "High", "Low", "Medium", "High", "High", "Low" };
        Dictionary<string, int> priorityCount = new Dictionary<string, int>();
        // TODO: Count each priority bucket
        foreach(string s in priorities)
        {
            if (priorityCount.ContainsKey(s))
            {
                priorityCount[s]++;
            }
            else
            {
                priorityCount.Add(s,1);
            }
        }
        foreach(var d in priorityCount)
        {
            Console.WriteLine($"Frequency of {d.Key} is {d.Value}");
        }
    }
}
