using System;
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

            int id = reader.GetInt32(0);
            int userId = reader.GetInt32(1);
            decimal humidity = reader.GetDecimal(2);
            decimal temperature = reader.GetDecimal(3);
            string dateTime = reader.GetDateTime(4).ToString("G");
            string location = reader.GetString(5);

            Model.Environment environment=new Model.Environment{Id = id,UserId = userId,Humidity = humidity,Temperatur = temperature,Location = location,DateTime = dateTime};
            return environment;
        }


        // GET: api/Enviroment/5
        [Route("{id}")]
        public List<Model.Environment> GetById(int id)
        {
            //SELECT * FROM dbo.Health WHERE UserId =1;
            string selectString = "Select * FROM dbo.Environment where UserId = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Model.Environment> result = new List<Model.Environment>();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Model.Environment environment = ReadEnviroment(reader);
                                result.Add(environment);
                            }
                            //reader.Read();
                            return result;


                        }
                        else
                        {
                            return null;
                        }


                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                        //    List<Model.Environment> result = new List<Model.Environment>();
                        //    while (reader.Read())
                        //    {
                        //        Model.Environment environment = ReadEnviroment(reader);
                        //        result.Add(environment);
                        //    }

                    }
                    }
            }

            return null;
        }

        // POST: api/Enviroment
        [HttpPost]
        public int Post([FromBody] Model.Environment value)
        {
            const string insertString = "INSERT INTO dbo.Environment(UserId,Humidity,Temperatur,Datetime,Location)VALUES" +
                                        "(@userId,@humidity,@temperature,@dateTime,@location)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@userId", value.UserId);
                    command.Parameters.AddWithValue("@humidity", value.Humidity);
                    command.Parameters.AddWithValue("@temperature", value.Temperatur);
                    command.Parameters.AddWithValue("@dateTime", value.DateTime);
                    command.Parameters.AddWithValue("@location", value.Location);
 
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // PUT: api/Enviroment/5
        [HttpPut("{id}")]
        //public int Put(int id, [FromBody] Model.Environment value)
        //{
        //    const string updateUser = "UPDATE dbo.Environment SET Oxygen=@oxygen,Nitrogen=@nitrogen,CarbonDioxide=@carbonDioxide,Methane=@methane,UserId=@userId WHERE Id=@id";
            
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (SqlCommand command = new SqlCommand(updateUser, conn))
        //        {
        //            command.Parameters.AddWithValue("@oxygen", value.Oxygen);
        //            command.Parameters.AddWithValue("@nitrogen", value.Nitrogen);
        //            command.Parameters.AddWithValue("@carbonDioxide", value.CarbonDioxide);
        //            command.Parameters.AddWithValue("@methane", value.Methane);
        //            command.Parameters.AddWithValue("@userId", value.UserId);
        //            command.Parameters.AddWithValue("@id", value.Id);


        //            int rowsAffected = command.ExecuteNonQuery();
        //            return rowsAffected;
        //        }
        //    }
        //}

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
