using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService1.DBAL
{
    public interface IBrockerDAO
    {
        BrockerTO FindById(int id);
        List<BrockerTO> FindAll();

        bool Update(BrockerTO t);
        bool Delete(BrockerTO t);
        int Insert(BrockerTO t);
    }
}
