using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Controllers;

namespace BirthaWebService.Model
{
    public static class IdentityUser
    {
       
            public static async Task<User> AuthenticateUser(User userToAuthenticate)
            {
                UserController uController = new UserController();
                var userList = uController.Get();

                var user = await Task.Run(() => userList.SingleOrDefault(x => x.Name == userToAuthenticate.Name && x.Password == userToAuthenticate.Password));

                if (user == null)
                {
                    return null;
                }

                user.Password = null; 
                return user;
            }
        
    }
}
