using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService1.DBAL
{
    public class TransactionDAO : ITransactionDAO
    {
        private MemoryPersistence mMP;

        public TransactionDAO(MemoryPersistence mp)
        {
            mMP = mp;
        }

        public TransactionTO FindById(int id)
        {
            var t = mMP.GetSingle(id);
            return (null != t) ? createTransferObject(t) : null;
        }

        public List<TransactionTO> FindAll()
        {
            var srcList = mMP.GetCollection();
            var dstList = convertListToTO(srcList);
            return dstList;
        }

        public List<TransactionTO> convertListToTO(List<Transaction> srcList)
        {
            var dstList = new List<TransactionTO>();
            foreach (Transaction srcT in srcList)
            {
                dstList.Add(createTransferObject(srcT));
            }

            return dstList;
        }

        public bool Update(TransactionTO t)
        {
            mMP.UpdateOrInsert(t);
            return true;
        }

        public bool Delete(TransactionTO t)
        {
            throw new NotImplementedException();
        }

        public int Insert(TransactionTO t)
        {
            var newId = mMP.UpdateOrInsert(t);
            return newId;
        }

        protected TransactionTO createTransferObject(Transaction src)
        {
            var dst = new TransactionTO(src.Price, src.Amount, src.ID);
            return dst;
        }
    }
}
