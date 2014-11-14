using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<TransactionTO> GetPage(int pageNo, int pageSize);

        [OperationContract]
        bool Save(TransactionTO t);

        [OperationContract]
        void Refresh();

        [OperationContract]
        void DumpData();
    }

}
