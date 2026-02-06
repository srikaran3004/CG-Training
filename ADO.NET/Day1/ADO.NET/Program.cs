using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
            "Initial Catalog=MyDatabase;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            try
            {
                Console.Write("Enter Gender (M/F):");
                string gender = Console.ReadLine().ToUpper();
                con.Open();
                Console.WriteLine("CONNECTED SUCCESSFULLY");

                //string query = "SELECT StdName, Dept FROM CollegeMaster";
                string query = "SELECT StdName, Dept FROM CollegeMaster WHERE Gender=@gender";

                using (SqlCommand command = new SqlCommand(query, con))
                //using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Console.WriteLine("\nCollege Data:");
                    //Console.WriteLine("--------------------");

                    //while (reader.Read())
                    //{
                    //    string name = reader["StdName"].ToString();
                    //    string dept = reader["Dept"].ToString();

                    //    Console.WriteLine($"Name: {name}, Dept: {dept}");
                    //}
                    command.Parameters.AddWithValue("@gender", gender);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\nCollege Data:");
                        Console.WriteLine("--------------------");

                        while (reader.Read())
                        {
                            string name = reader["StdName"].ToString();
                            string dept = reader["Dept"].ToString();

                            Console.WriteLine($"Name: {name}, Dept: {dept}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:");
                Console.WriteLine(ex.Message);
            }
        }

        Console.ReadLine();
    }
}
