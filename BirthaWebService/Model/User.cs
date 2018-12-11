using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Model
{
    public class User
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public bool IsAdmin { get; set; }
        public string Gender { get; set; }



        public User(int id, string name, string email, string password, bool isAdmin,string location,string gender)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Location = location;
            Gender = gender;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Email+" "+IsAdmin+" "+Location+" "+Gender+" ";
        }
    }
}
