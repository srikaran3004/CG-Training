using System;
using System.Diagnostics;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        // string path = "data.txt";
        // string path1 =  @"D:\Capgemini Training\C#\data1.txt";
        // File.WriteAllText(path, "File IO in data.txt");
        // Console.WriteLine("data.txt Data filled");
        // File.WriteAllText(path1, "File IO in data1.txt");
        // Console.WriteLine("File data1.txt created and data appended");

        //Read File:
        // string content = File.ReadAllText(path);
        // Console.WriteLine(content);
        // using (StreamWriter writer = new StreamWriter("log.txt"))
        // {
        //     writer.WriteLine("Application Started");
        //     writer.WriteLine("Processing Data");
        //     writer.WriteLine("Application Ended");
        // }
        // using (StreamReader reader = new StreamReader("log.txt"))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null)
        //     {
        //         Console.WriteLine(line);
        //     }
        // }
        //because we used using keyword, Dispose() already gets called after using block.
        // User user = new User { Id = 1, Name = "Srikaran" };

        // using (StreamWriter writer = new StreamWriter("user.txt"))
        // {
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        //     user.Id = 2;
        //     user.Name = "Pavan";
        //     writer.WriteLine(user.Id);
        //     writer.WriteLine(user.Name);
        // }

        // Console.WriteLine("User data saved.");
        // using (var reader = new StreamReader("user.txt"))
        // {
        //     string idLine;
        //     while ((idLine = reader.ReadLine()) != null)
        //     {
        //         string nameLine = reader.ReadLine();
        //         if (nameLine == null) break;
        //         Console.WriteLine($"User Loaded: {int.Parse(idLine)}, {nameLine}");
        //     }
        // }
        // User user = new User { Id = 2, Name = "Siva" };
        // using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        // {
        //     writer.Write(user.Id);
        //     writer.Write(user.Name);
        // }
        // Console.WriteLine("Binary user data saved.");
        using (BinaryWriter writer = new BinaryWriter(File.Open("data.bin", FileMode.Create)))
        {
            writer.Write(101);
            writer.Write("Binary Data");
        }
        using (BinaryReader reader = new BinaryReader(File.Open("data.bin", FileMode.Open)))
        {
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadString());
        }

    }
}
class User
{
    public int Id;
    public string Name;
}
