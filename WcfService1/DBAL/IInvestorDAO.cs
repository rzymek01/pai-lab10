using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.DBAL
{
    public interface IInvestorDAO
    {
        InvestorCE GetFullById(int id);
        InvestorCETO FindById(int id);
        List<InvestorCETO> FindAll();

        bool Update(InvestorCETO t);
        bool Delete(InvestorCETO t);
        int Insert(InvestorCETO t);
    }
}