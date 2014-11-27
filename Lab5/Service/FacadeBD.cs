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
    public class FacadeBD : BusinessDelegate<FacadeService.Service1Client>
    {
        private readonly object syncLock = new object();

        static private FacadeBD cInstance;
        static public FacadeBD Instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (null == cInstance)
                {
                    cInstance = new FacadeBD();
                }
                return cInstance;
            }
        }

        private FacadeBD()
            : base("facade")
        {
        
        }

        public InvestorsTO GetInvestors()
        {
            lock (syncLock)
            {
                var data = Service.GetInvestors();

                return data;
            }
        }

        public InvestorCETO GetInvestor(int id)
        {
            lock (syncLock)
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

        public void GetLatestTransaction(AsyncCallback callback)
        {
            lock (syncLock)
            {
                Service.BeginGetLatestTransaction(callback, null);
            }
        }
    }
}
