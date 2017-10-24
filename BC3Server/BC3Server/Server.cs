using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace BC3Server
{
    public class Server : Nancy.NancyModule
    {
        public Server()
        {
            var data = new MyRootdata
            {
                Data = "Meine ersten Daten",
                Data2 = "noch mehr Daten"
            };

            Get["/"] = _ => Response.AsJson(data);
        }
    }

}
