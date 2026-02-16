//using System;
//using System.Data;
//using System.Data.SqlClient;

//class Program
//{
//    static void Main()
//    {
//        string connectionString =
//            "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
//            "Initial Catalog=MyDatabase;" +
//            "Integrated Security=True;" +
//            "TrustServerCertificate=True;";
//        using (SqlConnection con = new SqlConnection(connectionString))
//        {
//            try
//            {
//                con.Open();
//                Console.WriteLine("CONNECTED SUCCESSFULLY");
//                using (SqlCommand command = new SqlCommand("sp_getstudentDetails1", con))
//                {
//                        command.CommandType = CommandType.StoredProcedure;
//                        int rowsAffected = command.ExecuteNonQuery();
//                        Console.WriteLine($"ROWS AFFECTED: {rowsAffected}");
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("ERROR:");
//                Console.WriteLine(ex.Message);
//            }
//        }

//        Console.ReadLine();
//    }
//}

//using System;
//using System.Data.SqlClient;

//class Program
//{
//    static void Main()
//    {
//        string connectionstring =
//            "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
//            "Initial Catalog=MyDatabase;" +
//            "Integrated Security=True;" +
//            "TrustServerCertificate=True;";
//        try
//        {
//            using SqlConnection con = new SqlConnection(connectionstring);
//            con.Open();
//            Console.WriteLine("connected successfully");
//            using SqlCommand countcmd = new SqlCommand("select count(*) from Hostel_info", con);
//            int count = (int)countcmd.ExecuteScalar();
//            if (count > 5)
//            {
//                using SqlCommand delcmd = new SqlCommand("delete from Hostel_info where roomno = 50", con);
//                int cnt=delcmd.ExecuteNonQuery();
//                Console.WriteLine($"deleted {cnt} rows ");
//            }
//            else if (count < 5)
//            {
//                using SqlCommand selcmd = new SqlCommand("select * from Hostel_info", con);
//                using SqlDataReader reader = selcmd.ExecuteReader();
//                while (reader.Read())
//                {
//                    for (int i = 0; i < reader.FieldCount; i++)
//                    {
//                        Console.Write(reader.GetName(i) + ": " + reader[i] + "  ");
//                    }
//                    Console.WriteLine();
//                }
//            }
//            else
//            {
//                Console.WriteLine("count equals 5, no action taken");
//            }
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("error:");
//            Console.WriteLine(ex.Message);
//        }

//        Console.ReadLine();
//    }
//}

//using System;
//using System.Data.SqlClient;

//class Program
//{
//    static void Main(string[] args)
//    {
//         string connectionString =
//        "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
//        "Initial Catalog=MyDatabase;" +
//        "Integrated Security=True;" +
//        "TrustServerCertificate=True;";
//        using (SqlConnection connection = new SqlConnection(connectionString))
//        {
//            connection.Open();
//            Console.WriteLine("Connection successful!");
//            string query = "select dbo.GetSquare(@num)";
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                command.CommandType = System.Data.CommandType.Text;
//                command.Parameters.AddWithValue("@num", 5);
//                int square = Convert.ToInt32(command.ExecuteScalar());
//                Console.WriteLine($"The square of 5 is: {square}");
//            }
//        }
//    }
//}

using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=10.35.2.16;" +
            "Database=MyDatabase;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Connected using IP address!");

            string query = "SELECT dbo.GetSquare(@num)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@num", 5);

                int square = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine($"Square of 5 = {square}");
            }
        }

        Console.ReadLine();
    }
}
