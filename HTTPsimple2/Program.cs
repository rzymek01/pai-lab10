using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Server.Server), new Uri[] { new Uri("http://localhost:8082") });

            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(Server.IServer), new WebHttpBinding(), "web");
            endpoint.EndpointBehaviors.Add(new WebHttpBehavior());

            ServiceDebugBehavior sdb = host.Description.Behaviors.Find<ServiceDebugBehavior>();
            sdb.HttpHelpPageEnabled = false;

            //var b = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            //if (b == null) b = new ServiceMetadataBehavior();
            //host.Description.Behaviors.Add(b);

            //host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            host.Open();

            Console.WriteLine("Server HTTP is running ...");
            Console.ReadLine();

            host.Close();
        }
    }
}
