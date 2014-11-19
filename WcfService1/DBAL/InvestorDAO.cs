using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService1.DBAL
{
    public class InvestorDAO : IInvestorDAO
    {
        private MemoryPersistence mMP;

        public InvestorDAO(MemoryPersistence mp)
        {
            mMP = mp;
        }

        public InvestorCE GetFullById(int id)
        {
            var t = mMP.GetSingleInvestor(id);
            return t;
        }
        
        public InvestorCETO FindById(int id)
        {
            var t = mMP.GetSingleInvestor(id);
            return (null != t) ? createLeanTransferObject(t) : null;
        }

        public List<InvestorCETO> FindAll()
        {
            var dstList = new List<InvestorCETO>();
            var srcList = mMP.GetInvestors();
            foreach (InvestorCE srcT in srcList)
            {
                dstList.Add(createLeanTransferObject(srcT));
            }

            return dstList;
        }

        public bool Update(InvestorCETO t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(InvestorCETO t)
        {
            throw new NotImplementedException();
        }

        public int Insert(InvestorCETO t)
        {
            throw new NotImplementedException();
        }

        public InvestorCETO createLeanTransferObject(InvestorCE src)
        {
            var dst = new InvestorCETO();
            dst.Person = createPersonTransferObject(src.Person);
            dst.Transactions = new List<TransactionTO>();
            return dst;
        }

        public InvestorCETO createFullTransferObject(InvestorCE src)
        {
            var tDAO = new TransactionDAO(mMP);
            
            var dst = new InvestorCETO();
            dst.Person = createPersonTransferObject(src.Person);
            dst.Transactions = tDAO.convertListToTO(src.Transactions);
            return dst;
        }

        protected PersonTO createPersonTransferObject(Person src)
        {
            var result = new PersonTO(src.Firstname, src.Surname, src.ID);
            return result;
        }
    }
}
