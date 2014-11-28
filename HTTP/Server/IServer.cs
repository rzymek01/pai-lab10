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
        [WebInvoke(Method = "GET", UriTemplate = "/{path}")]
        System.IO.Stream Get(string path);

        //[OperationContract]
        //[WebInvoke(Method = "GET", UriTemplate = "/Add?num1={num1}&num2{num2}", ResponseFormat = WebMessageFormat.Json)]
        //string Add(string num1, string num2);
    }
}
