using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Environment = System.Environment;

namespace BirthaWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/Enviroment
        [HttpGet]
        public IEnumerable<Model.Environment> Get()
        {

            string selectString = "SELECT * FROM dbo.Environment";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Model.Environment> result = new List<Model.Environment>();
                        while (reader.Read())
                        {
                            Model.Environment environment = ReadEnviroment(reader);
                            result.Add(environment);
                        }

                        return result;
                    }
                }
            }


            return null;
        }

        private Model.Environment ReadEnviroment(SqlDataReader reader)
        {
        //public int Id { get; set; }
        //public int Oxygen { get; set; }
        //public int CarbonDioxide { get; set; }
        //public int Methane { get; set; }
        //public int UserId { get; set; }
            int id = reader.GetInt32(0);
            int oxygen = reader.GetInt32(1);
            int nitrogen = reader.GetInt32(2);
            int carbonDioxide = reader.GetInt32(3);
            int methane = reader.GetInt32(4);
            int userId = reader.GetInt32(5);
            Model.Environment environment=new Model.Environment{CarbonDioxide = carbonDioxide,Id = id,Nitrogen = nitrogen,Methane = methane,Oxygen = oxygen,UserId = userId};
            return environment;
        }


        // GET: api/Enviroment/5
        [Route("{id}")]
        public Model.Environment Get(int id)
        {
            string selectString = "Select * FROM dbo.Environment where id = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            return ReadEnviroment(reader);

                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return null;
        }

        // POST: api/Enviroment
        [HttpPost]
        public int Post([FromBody] Model.Environment value)
        {
            const string insertString = "INSERT INTO dbo.Environment(Oxygen,Nitrogen,CarbonDioxide,Methane,UserId)VALUES" +
                                        "(@oxygen,@nitrogen,@carbonDioxide,@methane,@userId)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    command.Parameters.AddWithValue("@nitrogen", value.Nitrogen);
                    command.Parameters.AddWithValue("@carbonDioxide", value.CarbonDioxide);
                    command.Parameters.AddWithValue("@methane", value.Methane);
                    command.Parameters.AddWithValue("@userid", value.UserId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // PUT: api/Enviroment/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Model.Environment value)
        {
            const string updateUser = "UPDATE dbo.Environment SET Oxygen=@oxygen,Nitrogen=@nitrogen,CarbonDioxide=@carbonDioxide,Methane=@methane,UserId=@userId WHERE Id=@id";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateUser, conn))
                {
                    command.Parameters.AddWithValue("@oxygen", value.Oxygen);
                    command.Parameters.AddWithValue("@nitrogen", value.Nitrogen);
                    command.Parameters.AddWithValue("@carbonDioxide", value.CarbonDioxide);
                    command.Parameters.AddWithValue("@methane", value.Methane);
                    command.Parameters.AddWithValue("@userId", value.UserId);
                    command.Parameters.AddWithValue("@id", value.Id);


                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            const string deleteStatement = "DELETE FROM dbo.Environment where id =@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(deleteStatement, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
