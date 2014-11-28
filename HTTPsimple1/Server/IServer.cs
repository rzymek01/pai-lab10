using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Server
{
    [ServiceContract]
    public interface IServer
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/get?token={token}", ResponseFormat = WebMessageFormat.Json)]
        TransactionTO GetData(String token);

    }
}
