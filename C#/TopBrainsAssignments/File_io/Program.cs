using System;
using System.IO;

class Program
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("log.txt");
        StreamWriter sw = new StreamWriter("error.txt");

        foreach (string line in lines)
        {
            if (line.Contains("ERROR"))
                sw.WriteLine(line);
        }
        sw.Close();
    }
}
