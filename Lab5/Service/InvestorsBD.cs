using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5.Service
{
    public class InvestorsBD : BusinessDelegate<ServiceReference1.Service1Client>
    {

        public InvestorsBD() : base("investors")
        {
        
        }

        public InvestorsTO GetInvestors()
        {
            Service.Open();
            var data = Service.GetInvestors();
            Service.Close();

            return data;
        }

        public InvestorCETO GetInvestor(int id)
        {
            InvestorCETO data = null;
            try
            {
                Service.Open();
                data = Service.GetInvestor(id); 
            }
            catch (FaultException<NotFoundException> ex)
            {
                MessageBox.Show(ex.Detail.Message);
            }
            finally
            {
                Service.Close();
            }

            return data;
        }
    }
}
