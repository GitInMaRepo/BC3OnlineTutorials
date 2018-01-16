using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

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
                id = "1",
                Data = "Meine ersten Daten",
                Data1 = "noch mehr Daten"
            },
            new Person
            {
                id = "2",
                Data = "Hans",
                Data1 = "Huber"
            },
            new Person
            {
                id = "3",
                Data = "Fritz",
                Data1 = "Fischer"
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

            Get["/{id}"] = parameter =>
            {
                string index = parameter.id;
                return Response.AsJson(dataList.FirstOrDefault(i => i.id == index))
                            .WithHeader("Access-Control-Allow-Origin", "*")
                            .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                            .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            };

            Options["/Set"] = parameter =>
           {
               return Response.AsJson(Request)
              .WithHeader("Access-Control-Allow-Origin", "*")
              .WithHeader("Access-Control-Allow-Methods", "POST")
              .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
           };

            Post["/Set"] = parameter =>
                {
                    var model = this.Bind<Person>();
                    dataList.Add(model);
                    return null;
                };
        }
    }
}
