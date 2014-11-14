using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService1.DBAL
{
    public interface ITransactionDAO
    {
        TransactionTO FindById(int id);
        List<TransactionTO> FindAll();

        bool Update(TransactionTO t);
        bool Delete(TransactionTO t);
        int Insert(TransactionTO t);
    }
}
