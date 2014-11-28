using ClassLibrary1;
using ClassLibrary1.Filter;
using HTTP.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Server
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class Server : IServer
    {
        private FilterManager mFilterManager;
        public Server()
        {
            mFilterManager = new FilterManager();
        }

        public BrockerTO GetData(String token)
        {
            if (!mFilterManager.checkFilters(token))
            {
                return null;
            }

            var random = new Random();
            var no = random.Next() % 91;
            var brocker = new BrockerTO("broker nr " + no.ToString(), 1);
            return brocker;
        }
    }
}
