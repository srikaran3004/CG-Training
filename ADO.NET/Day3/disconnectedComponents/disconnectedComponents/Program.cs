using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connectionString =
        "Server=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
        "Database=MyDatabase;" +
        "Integrated Security=True;" +
        "TrustServerCertificate=True;";

    static DataSet ds = new DataSet();
    static SqlDataAdapter adapter;

    static void Main()
    {
        LoadData();

        int choice;
        do
        {
            Console.WriteLine("\n==== STUDENT MANAGEMENT (DISCONNECTED) ====");
            Console.WriteLine("1. Display all students");
            Console.WriteLine("2. Filter students by Department");
            Console.WriteLine("3. Update student marks");
            Console.WriteLine("4. Add new student");
            Console.WriteLine("5. Save changes to database");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayStudents();
                    break;

                case 2:
                    FilterByDepartment();
                    break;

                case 3:
                    UpdateMarks();
                    break;

                case 4:
                    AddStudent();
                    break;

                case 5:
                    SaveChanges();
                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 0);
    }

    // 🔹 LOAD DATA (Disconnected)
    static void LoadData()
    {
        using SqlConnection con = new SqlConnection(connectionString);

        adapter = new SqlDataAdapter("SELECT * FROM CollegeMaster", con);

        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

        adapter.Fill(ds, "CollegeMaster");
    }

    // 🔹 DISPLAY
    static void DisplayStudents()
    {
        DataTable table = ds.Tables["CollegeMaster"];

        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine(
                $"{row["StdId"],-3} {row["StdName"],-10} {row["Dept"],-18} " +
                $"M1:{row["M1"],-3} M2:{row["M2"],-3} M3:{row["M3"],-3} Total:{row["Total"]}"
            );
        }
    }

    // 🔹 FILTER
    static void FilterByDepartment()
    {
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine();

        DataRow[] rows = ds.Tables["CollegeMaster"]
            .Select($"Dept = '{dept}'");

        if (rows.Length == 0)
        {
            Console.WriteLine("No records found");
            return;
        }

        foreach (DataRow row in rows)
        {
            Console.WriteLine($"{row["StdId"]} {row["StdName"]} {row["Dept"]}");
        }
    }

    // 🔹 UPDATE
    static void UpdateMarks()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        DataRow row = ds.Tables["CollegeMaster"].Rows.Find(id);

        if (row == null)
        {
            Console.WriteLine("Student not found");
            return;
        }

        Console.Write("Enter new M1: ");
        row["M1"] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new M2: ");
        row["M2"] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter new M3: ");
        row["M3"] = Convert.ToInt32(Console.ReadLine());

        row["Total"] =
            Convert.ToInt32(row["M1"]) +
            Convert.ToInt32(row["M2"]) +
            Convert.ToInt32(row["M3"]);

        Console.WriteLine("Marks updated (IN MEMORY ONLY)");
    }

    // 🔹 INSERT
    static void AddStudent()
    {
        DataTable table = ds.Tables["CollegeMaster"];
        DataRow row = table.NewRow();

        Console.Write("StdId: ");
        row["StdId"] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Name: ");
        row["StdName"] = Console.ReadLine();

        Console.Write("Gender: ");
        row["Gender"] = Console.ReadLine();

        Console.Write("Age: ");
        row["Age"] = Convert.ToInt32(Console.ReadLine());

        Console.Write("Department: ");
        row["Dept"] = Console.ReadLine();

        row["Year"] = 1;
        row["CourseName"] = "Dotnet";
        row["State"] = "Chennai";
        row["M1"] = 0;   
        row["M2"] = 0;
        row["M3"] = 0;
        row["Total"] = 0;

        table.Rows.Add(row);

        Console.WriteLine("Student added (IN MEMORY ONLY)");
    }

    // 🔹 SAVE TO DATABASE
    static void SaveChanges()
    {
        adapter.Update(ds, "CollegeMaster");
        Console.WriteLine("Changes saved to database");
    }
}
