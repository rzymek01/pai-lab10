using HTTP.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Server
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class Server : IServer
    {
        private FrontController mFrontCtrl;
        private ViewHelper mViewHelper;
        public Server()
        {
            mViewHelper = new ViewHelper();
            mFrontCtrl = new FrontController(mViewHelper);
        }

        public System.IO.Stream Get(string path)
        {
            if (!mViewHelper.Logged)
            {
                path = "login";
            }

            string result = mFrontCtrl.Process(path);
            byte[] resultBytes = Encoding.UTF8.GetBytes(result);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(resultBytes);
        }

        public Stream Auth(string login, string passwd)
        {
            Console.WriteLine(login + " " + passwd);
            mViewHelper.Auth(login, passwd);

            string result = (mViewHelper.Logged) ? "zalogowano" : "niezalogowano";
            byte[] resultBytes = Encoding.UTF8.GetBytes(result);
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            return new MemoryStream(resultBytes);
        }
    }
}
