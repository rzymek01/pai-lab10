using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class InvestorsTOA
    {
        private DBAL.BrockerDAO mBrockerDAO;
        private DBAL.InvestorDAO mInvestorDAO;

        public InvestorsTOA(DBAL.BrockerDAO bDAO, DBAL.InvestorDAO iDAO)
        {
            mBrockerDAO = bDAO;
            mInvestorDAO = iDAO;
        }

        public InvestorsTO GetInvestors()
        {
            var result = new InvestorsTO();

            var brockers = mBrockerDAO.FindAll();
            result.Brockers = brockers;

            var investors = mInvestorDAO.FindAll();
            result.Investors = investors;

            //var rawItem = mInvestorDAO.GetFullById(1);
            //var item = mInvestorDAO.createFullTransferObject(rawItem);
            //result.Investors = new List<InvestorCETO>();
            //result.Investors.Add(item);

            return result;
        }
    }
}