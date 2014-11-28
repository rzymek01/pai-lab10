using HTTP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.View
{
    public class TransactionView : IView
    {
        public TransactionView(ViewHelper vh) : base(vh)
        {
 
        }

        override public string Render()
        {
            var client = new ViewService.Service1Client();
            client.Open();
            var result = client.GetTransactionsPage();
            client.Close();
            return result;
        }
    }
}
