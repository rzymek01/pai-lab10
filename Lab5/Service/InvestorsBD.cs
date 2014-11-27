using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5.Service
{
    public class InvestorsBD : BusinessDelegate<ServiceReference1.Service1Client>
    {

        static private InvestorsBD cInstance;
        static public InvestorsBD Instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (null == cInstance)
                {
                    cInstance = new InvestorsBD();
                }
                return cInstance;
            }
        }

        private InvestorsBD() : base("investors")
        {
        
        }

        public InvestorsTO GetInvestors()
        {
            var data = Service.GetInvestors();

            return data;
        }

        public InvestorCETO GetInvestor(int id)
        {
            InvestorCETO data = null;
            try
            {
                data = Service.GetInvestor(id);
            }
            catch (FaultException<NotFoundException> ex)
            {
                MessageBox.Show(ex.Detail.Message);
            }
            finally
            {
            
            }

            return data;
        }
    }
}
