using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ado.net_based_on_conditions
{
    public class ado
    {
        static void Main()
        {
            string connectionString =
                "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
                "Initial Catalog=MyDatabase;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    // Open connection
                    connection.Open();
                    Console.WriteLine("Connection successful!");


                    using (SqlCommand command = new SqlCommand("sp_getstudentDetails", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("\nCollege Data:");
                            while (reader.Read())
                            {
                                Console.WriteLine(
                                    $"Name: {reader[0]}, Department: {reader[1]}"
                                );
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }

            Console.WriteLine("Connection closed.");
        }
    }
}
