using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    /**
     * Composite Entity
     */
    public class InvestorCE
    {
        private List<Transaction> mTransactions;
        private DBAL.InvestorDAO mDAO;

        public Person Person
        {
            get;
            set;
        }

        public List<Transaction> Transactions
        {
            get
            {
                // lazy loading
                if (null == mTransactions)
                {
                    var src = mDAO.GetFullById(Person.ID);
                    mTransactions = src.Transactions;
                }

                return mTransactions;
            }
            protected set
            {
                mTransactions = value;
            }
        }

        public InvestorCE(DBAL.InvestorDAO dao, Person person = null, List<Transaction> transactions = null)
        {
            mTransactions = transactions;
            Person = person;
            mDAO = dao;
        }

    }
}