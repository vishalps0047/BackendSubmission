using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application.Models
{
    public class ConfigHelper
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }

    public class ConnectionStrings
    {
        public string IdentityConnection { get; set; }
    }
}
