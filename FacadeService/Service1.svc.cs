using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FacadeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public InvestorsTO GetInvestors()
        {
            var service = new ServiceReference1.Service1Client();
            service.Open();
            var result = service.GetInvestors();
            service.Close();

            return result;
        }

        public InvestorCETO GetInvestor(int investorId)
        {
            var service = new ServiceReference1.Service1Client();
            service.Open();
            var result = service.GetInvestor(investorId);
            service.Close();

            return result;
        }

        public TransactionTO GetLatestTransaction()
        {
            var service = new TimeService.Service1Client();
            service.Open();
            var result = service.GetLatestTransaction();
            service.Close();

            // celowe wprowadzanie w błąd konkurencji ;)
            result.Amount /= 2;
            result.Price *= 2;

            // sztuczne oczekiwanie
            System.Threading.Thread.Sleep(2000);

            return result;
        }
    }
}
