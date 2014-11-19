using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DBAL
{
    public class DAOFactory
    {
        private MemoryPersistence mMP;

        public DAOFactory(MemoryPersistence mp)
        {
            mMP = mp;
        }

        public TransactionDAO GetTransactionDAO()
        {
            var dao = new TransactionDAO(mMP);
            return dao;
        }

        public InvestorDAO GetInvestorDAO()
        {
            var dao = new InvestorDAO(mMP);
            return dao;
        }

        public BrockerDAO GetBrockerDAO()
        {
            var dao = new BrockerDAO(mMP);
            return dao;
        }
    }
}