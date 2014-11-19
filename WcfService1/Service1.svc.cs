using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private DBAL.MemoryPersistence mMP;
        private ValueListHandler mVLH;
        private DBAL.TransactionDAO mDAO;
        private DBAL.InvestorDAO iDAO;
        private DBAL.BrockerDAO bDAO;

        public Service1()
        {
            mMP = new DBAL.MemoryPersistence(@"C:\__debug.txt");
            mMP.LoadFromFile();

            var daoFactory = new DBAL.DAOFactory(mMP);
            mDAO = daoFactory.GetTransactionDAO();
            iDAO = daoFactory.GetInvestorDAO();
            bDAO = daoFactory.GetBrockerDAO();

            Refresh();
        }

        public InvestorsTO GetInvestors()
        {
            var toa = new InvestorsTOA(bDAO, iDAO);
            var result = toa.GetInvestors();
            return result;
        }

        public InvestorCETO GetInvestor(int investorId)
        {
            var inv = iDAO.GetFullById(investorId);
            if (null != inv)
                return iDAO.createFullTransferObject(inv);
            else
            {
                var ex = new NotFoundException("Nie odnaleziono inwestora o id równym " + investorId.ToString());
                throw new FaultException<NotFoundException>(ex);
            }
        }

        public List<TransactionTO> GetPage(int pageNo, int pageSize)
        {
            var result = mVLH.GetPage(pageNo, pageSize);
            return result;
        }

        public bool Save(TransactionTO t)
        {
            return mDAO.Update(t);
        }

        public void Refresh()
        {
            mVLH = new ValueListHandler(mDAO);
        }

        public void DumpData()
        {
            mMP.SaveToFile();
        }
    }
}
