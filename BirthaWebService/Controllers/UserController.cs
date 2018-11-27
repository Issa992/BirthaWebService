using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Model;
using Microsoft.AspNetCore.Mvc;

namespace BirthaWebService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            string selectString = "select * from dbo.[user]";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<User> result = new List<User>();
                        while (reader.Read())
                        {
                            User customer = ReadUser(reader);
                            result.Add(customer);
                        }

                        return result;
                    }
                }
            }


            return null;
        }

        private User ReadUser(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string email = reader.GetString(2);
            string password = reader.GetString(3);
            bool isAdmin = reader.GetBoolean(4);
            string location = reader.GetString(5);

            User user = new User { Id = id, Name = name, Email = email, Password = password,IsAdmin = isAdmin,Location = location};
            return user;

        }

        //Login with ID
        [Route("login/{name}/{password}")]
        public User Login(string name, string password)
        {
            bool loginStatus = false;
            var collection = Get();
            if (collection !=null)
            {
                foreach (var user in collection)
                {
                    if ((user.Name==name)&&(user.Password==password))
                    {
                        loginStatus = true;
                        return user;
                    }
                }
            }

            loginStatus = false;
            return null;
        }

        // GET: api/User/5
        [Route("{id}")]
        public User GetById(int id)
        {
            string selectString = "Select * FROM dbo.[User] where id = @id";
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
                            return ReadUser(reader);

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



        // POST: api/User
        [HttpPost]
        public int AddUser([FromBody] User value)
        {
            //INSERT INTO dbo.[User](Name,Email,Password)VALUES('Ben','ben@gmail.com','1234')
            const string insertString = "INSERT INTO dbo.[User](Name,Email,Password,IsAdmin,Location)VALUES(@name,@email,@password,@IsAdmin,@location)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(insertString, conn))
                {
                    command.Parameters.AddWithValue("@name", value.Name);
                    command.Parameters.AddWithValue("@email", value.Email);
                    command.Parameters.AddWithValue("@password", value.Password);
                    command.Parameters.AddWithValue("@IsAdmin", value.IsAdmin);
                    command.Parameters.AddWithValue("@location", value.Location);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }

            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public int UpdateUser(int id, [FromBody] User value)
        {
            const string updateUser =
                "UPDATE dbo.[User] SET Name=@name,Email=@email,Password=@password,IsAdmin=@isAdmin,Location=@location WHERE Id=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(updateUser, conn))
                {
                    command.Parameters.AddWithValue("@name", value.Name);
                    command.Parameters.AddWithValue("@email", value.Email);
                    command.Parameters.AddWithValue("@password", value.Password);
                    command.Parameters.AddWithValue("@id", value.Id);
                    command.Parameters.AddWithValue("@isAdmin", value.IsAdmin);
                    command.Parameters.AddWithValue("@location", value.Location);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int DeleteUser(int id)
        {
            const string deleteStatement = "DELETE FROM dbo.[User] where id =@id";
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
