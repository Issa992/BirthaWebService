using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Model
{
    public class User
    {

        //[Id] INT IDENTITY(1, 1) NOT NULL,

        //[Name]     VARCHAR(50)   NOT NULL,

        //[Email]    VARCHAR(50)   NOT NULL,

        //[Password] NVARCHAR(MAX) NOT NULL,

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Email;
        }
    }
}
