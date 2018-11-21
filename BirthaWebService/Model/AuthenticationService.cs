using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Controllers;

namespace BirthaWebService.Model
{
   
        public static class AuthenticationService
        {
            public static async Task<User> AuthenticateUser(User userToAuthenticate)
            {
                UserController userController = new UserController();
                var UserList = userController.Get();

                var user = await Task.Run(() => UserList.SingleOrDefault(s => s.Name == userToAuthenticate.Name && s.Password == userToAuthenticate.Password));

                if (user == null)
                {
                    return null;
                }

                user.Password = null; 
                return user;
            }
        }
    
}
