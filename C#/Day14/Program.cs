// using System.Text.Json;
// using System.IO;
// using System.Xml.Serialization;
// /**
// class Program
// {
//     static void Main()
//     {
//         // FileInfo file = new FileInfo("sample.txt");
//         // if (!file.Exists)
//         // {
//         //     using (StreamWriter writer = file.CreateText())
//         //     {
//         //         writer.WriteLine("I'm Srikaran");
//         //     }
//         // }
//         // Console.WriteLine("File Name: " + file.Name);
//         // Console.WriteLine("File Size: " + file.Length + " bytes");
//         // Console.WriteLine("Created On: " + file.CreationTime);


//         // DIRECTORY CLASS
//         // Directory.CreateDirectory("Logs");
//         // if (Directory.Exists("Logs"))
//         // {
//         //     Console.WriteLine("Logs directory created successfully.");
//         // }
//         //Directory class as we don't create an obj, current and prev state are not stored, so everytime any changes happens it need to do all system checks.

//         //DIRECTORY INFO
//         //  DirectoryInfo dir = new DirectoryInfo("Logs1");
//         // if (!dir.Exists)
//         // {
//         //     dir.Create();
//         // }
//         // Console.WriteLine("Directory Name: " + dir.Name);
//         // Console.WriteLine("Created On: " + dir.CreationTime);
//         // Console.WriteLine("Full Path: " + dir.FullName);

//         //SERIALIZATION
//         //Serialization in C# is the process of converting an object into a format that can be stored or transmitted, such as a file, memory stream, or network stream.
//         User user = new() { Id = 2, Name = "Srikaran" };
//         // string json = JsonSerializer.Serialize(user);
//         // File.AppendAllText("user.json", json + Environment.NewLine);
//         // Console.WriteLine("User serialized successfully.");

//         //DESERIALIZATION
//         // string json = File.ReadAllText("user.json");
//         // User user = JsonSerializer.Deserialize<User>(json);
//         // Console.WriteLine($"User Loaded: {user.Id}, {user.Name}");

//         //XML SERIALIZATION
//         // XmlSerializer serializer = new XmlSerializer(typeof(User));
//         // using (FileStream fs = new FileStream("user.xml", FileMode.Create))
//         // {
//         //     serializer.Serialize(fs, user);
//         // }

//         // Console.WriteLine("XML Serialized");
//         // Console.WriteLine(typeof(User));
//     }
// }
// // [Serializable]
// // public class User
// // {
// //     public int Id { get; set; }
// //     public string Name { get; set; }
// // }
// [DataContract]
// public class User
// {
//     [DataMember]
//     public int Id { get; set; }

//     [DataMember]
//     public string Name { get; set; }
// }
// **/
// public class Student
// {
//     public int RollNo{get;set;}
//     public string Name{get;set;}
//     public int Marks{get;set;}
//     public char SportsGrade{get;set;}
//     public static string GetEligibleStudents(List<Student>studentsList, IsEligibleforScholarship isEligible)
//     {
        
//     }

// }
// class Program
// {
//     public static bool ScholarshipEligibility(Student std){}
// }
