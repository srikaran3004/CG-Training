
using System;
using System.Data;
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
                Console.Write("Enter Gender (M/F): ");
                string gender = Console.ReadLine().ToUpper();

                con.Open();

                using (SqlCommand cmd = new SqlCommand("sp_getGenderCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Gender", gender);

                    SqlParameter outputParam = new SqlParameter("@Cnt", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    int count = (int)cmd.Parameters["@Cnt"].Value;

                    Console.WriteLine($"Total students with gender {gender}: {count}");
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
