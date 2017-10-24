using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC3Server
{
    public class Server : Nancy.NancyModule
    {
        public Server()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}
