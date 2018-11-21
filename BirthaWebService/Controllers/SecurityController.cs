using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthaWebService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthaWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        // POST: api/Security
        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] User userToAuthenticate)
        {
            var user = await AuthenticationService.AuthenticateUser(userToAuthenticate);

            if (user == null)
       
                return Unauthorized();

            return Ok(user);
        }


    }
}
