using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthaWebService.Controllers
{
    public class ConnectionString
    {
        public static readonly string connectionString = "Server=tcp:birthserver.database.windows.net,1433;Initial Catalog=BirthaDb;Persist Security Info=False;User ID=issa;Password=12345678abC;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }

}
