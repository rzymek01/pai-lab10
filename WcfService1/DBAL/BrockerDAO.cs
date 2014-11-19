using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService1.DBAL
{
    public class BrockerDAO : IBrockerDAO
    {
        private MemoryPersistence mMP;

        public BrockerDAO(MemoryPersistence mp)
        {
            mMP = mp;
        }

        public BrockerTO FindById(int id)
        {
            var t = mMP.GetSingleBrocker(id);
            return (null != t) ? createTransferObject(t) : null;
        }

        public List<BrockerTO> FindAll()
        {
            var dstList = new List<BrockerTO>();
            var srcList = mMP.GetBrockers();
            foreach (Brocker srcT in srcList)
            {
                dstList.Add(createTransferObject(srcT));
            }

            return dstList;
        }

        public bool Update(BrockerTO t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BrockerTO t)
        {
            throw new NotImplementedException();
        }

        public int Insert(BrockerTO t)
        {
            throw new NotImplementedException();
        }

        protected BrockerTO createTransferObject(Brocker src)
        {
            var dst = new BrockerTO(src.Name, src.ID);
            return dst;
        }
    }
}
