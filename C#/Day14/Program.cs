using System;
using System.IO;

class Program
{
    static void Main()
    {
        FileInfo file = new FileInfo("sample.txt");
        if (!file.Exists)
        {
            using (StreamWriter writer = file.CreateText())
            {
                writer.WriteLine("I'm Srikaran");
            }
        }
        Console.WriteLine("File Name: " + file.Name);
        Console.WriteLine("File Size: " + file.Length + " bytes");
        Console.WriteLine("Created On: " + file.CreationTime);
    }
}
