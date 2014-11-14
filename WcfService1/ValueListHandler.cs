using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class ValueListHandler : ValueListIterator<TransactionTO>
    {
        private DBAL.ITransactionDAO mTransactionDAO;
        private List<TransactionTO> mData;

        public ValueListHandler(DBAL.ITransactionDAO tDAO)
        {
            mTransactionDAO = tDAO;
            mData = tDAO.FindAll();
        }
        
        public int GetSize()
        {
            return mData.Count;
        }

        public List<TransactionTO> GetPage(int pageNo, int pageSize)
        {
            int startIndex = (pageNo - 1) * pageSize,
                endIndex = pageNo * pageSize - 1;

            if (endIndex >= GetSize())
            {
                endIndex = GetSize() - 1;
            }

            var dstList = new List<TransactionTO>();
            for (var i = startIndex; i <= endIndex; ++i)
            {
                dstList.Add(mData[i]);
            }

            return dstList;
        }
    }
}