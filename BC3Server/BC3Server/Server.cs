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
            List<Person> dataList = new List<Person>
            {
                new Person
            {
                Data = "Meine ersten Daten",
                Data2 = "noch mehr Daten"
            },
            new Person
            {
                Data = "Hans",
                Data2 = "Huber"
            },
            new Person
            {
                Data = "Fritz",
                Data2 = "Fischer"
            }
            };

            Get["/"] = _ => Response.AsJson(dataList.FirstOrDefault())
                            .WithHeader("Access-Control-Allow-Origin", "*")
                            .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

            Get["/All"] = _ => Response.AsJson(dataList)
                            .WithHeader("Access-Control-Allow-Origin", "*")
                            .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

        }
    }

}
