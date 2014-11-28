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

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/auth?login={login}&passwd={passwd}")]
        System.IO.Stream Auth(String login, String passwd);

    }
}
