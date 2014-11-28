using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.View
{
    public class InvestorView : IView
    {
        public string Render()
        {
            var client = new ViewService.Service1Client();
            client.Open();
            var result = client.GetInvestorsPage();
            client.Close();
            return result;
        }
    }
}
