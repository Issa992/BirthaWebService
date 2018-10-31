using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthaWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/Health
        [HttpGet]
        public IEnumerable<Health> Get()
        {
            string selectString = "SELECT * FROM dbo.Health";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Health> result = new List<Health>();
                        while (reader.Read())
                        {
                            Health heath = ReadHeath(reader);
                            result.Add(heath);
                        }

                        return result;
                    }
                }
            }


            return null;
        }

        private Health ReadHeath(SqlDataReader reader)
        {

            int id = reader.GetInt32(0);
            int bloodPressure = reader.GetInt32(1);
            int heartBeat = reader.GetInt32(2);
            int age = reader.GetInt32(3);
            int weight = reader.GetInt32(4);
            string gender = reader.GetString(5);
            int userId = reader.GetInt32(6);

            Health health=new Health{Age =age,BloodPressure=bloodPressure ,HeartBeat = heartBeat,Gender = gender,Id = id,Weight = weight,UserId = userId};
            return health;



        }

        // GET: api/Health/5
        [Route("{id}")]
        public Health Get(int id)
        {
            string selectString = "Select * FROM dbo.[Health] where id = @id";
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
                            return ReadHeath(reader);

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

        // POST: api/Health
        [HttpPost]
        public int AddHealth([FromBody] Health value)
        {
            const string insertString = "INSERT INTO dbo.Health(BloodPressure,HeartBeat,Age,Weight,Gender,UserId)VALUES(" +
                                        "@bloodPressure,@heartBeat,@age,@gender,@userid)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@bloodPressure", value.BloodPressure);
                    command.Parameters.AddWithValue("@heartBeat", value.HeartBeat);
                    command.Parameters.AddWithValue("@age", value.Age);
                    command.Parameters.AddWithValue("@gender", value.Gender);
                    command.Parameters.AddWithValue("@userid", value.UserId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // PUT: api/Health/5
        [HttpPut("{id}")]
        public int UpdateHealth(int id, [FromBody] Health value)
        {
            const string updateUser =
                //UPDATE dbo.Health SET BloodPressure=2,HeartBeat=20,Age=21,Weight=40,Gender='Female',UserId=5 WHERE Id=4
                "UPDATE dbo.Health SET BloodPressure=@bloodPressure,HeartBeat=@heartBeat,Age=@age,Weight=@weight,Gender=@gender,UserId=@userId WHERE Id=@id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateUser, conn))
                {
                    command.Parameters.AddWithValue("@bloodPressure", value.BloodPressure);
                    command.Parameters.AddWithValue("@heartBeat", value.HeartBeat);
                    command.Parameters.AddWithValue("@age", value.Age);
                    command.Parameters.AddWithValue("@weight", value.Weight);
                    command.Parameters.AddWithValue("@gender", value.Gender);
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
            const string deleteStatement = "DELETE FROM dbo.[Health] where id =@id";
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
