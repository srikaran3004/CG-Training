using System.Data.SqlClient;
using CRUDApplicationMVC.Models;

namespace CRUDApplicationMVC.DAL
{
    public class PersonDAL
    {
        string connectionString =
        "Data Source=ASUS-VIVOBOOK-1\\SQLEXPRESS;" +
        "Initial Catalog=MvcADO.NET;" +
        "Integrated Security=True;" +
        "TrustServerCertificate=True;";

        // COMMON SELECT METHOD
        private List<PersonModel> ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            List<PersonModel> list = new List<PersonModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new PersonModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Age = Convert.ToInt32(dr["Age"]),
                        State = dr["State"].ToString()
                    });
                }
            }
            return list;
        }

        // COMMON INSERT UPDATE DELETE METHOD
        private void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(parameters);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SELECT ALL
        public List<PersonModel> GetAllPersons()
        {
            return ExecuteQuery("SELECT * FROM PersonDetails");
        }

        // SELECT BY ID
        public PersonModel GetPersonById(int id)
        {
            return ExecuteQuery(
                "SELECT * FROM PersonDetails WHERE Id=@Id",
                new SqlParameter[] { new SqlParameter("@Id", id) }
            ).FirstOrDefault();
        }

        // INSERT
        public void AddPerson(PersonModel p)
        {
            ExecuteNonQuery(
                "INSERT INTO PersonDetails(Name,Age,State) VALUES(@Name,@Age,@State)",
                new SqlParameter[]
                {
                    new SqlParameter("@Name", p.Name),
                    new SqlParameter("@Age", p.Age),
                    new SqlParameter("@State", p.State)
                });
        }

        // UPDATE
        public void UpdatePerson(PersonModel p)
        {
            ExecuteNonQuery(
                "UPDATE PersonDetails SET Name=@Name,Age=@Age,State=@State WHERE Id=@Id",
                new SqlParameter[]
                {
                    new SqlParameter("@Id", p.Id),
                    new SqlParameter("@Name", p.Name),
                    new SqlParameter("@Age", p.Age),
                    new SqlParameter("@State", p.State)
                });
        }

        // DELETE
        public void DeletePerson(int id)
        {
            ExecuteNonQuery(
                "DELETE FROM PersonDetails WHERE Id=@Id",
                new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                });
        }
    }
}