using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TimeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public TransactionTO GetLatestTransaction()
        {
            var trans = new TransactionTO(207.9f, 10000, 999);
            return trans;
        }


        public string GetInvestorsPage()
        {
            return "<html><head><title>Inwestorzy</title></head><body>" +
                "<h1>Inwestorzy</h1><a href=\"transactions\">Skocz do transakcji</a>" +
                "</body></html>";
        }

        public string GetTransactionsPage()
        {
            return "<html><head><title>Transakcje</title></head><body>" +
                "<h1>Transakcje</h1><a href=\"investors\">Skocz do inwestorów</a>" +
                "</body></html>";
        }
    }
}
