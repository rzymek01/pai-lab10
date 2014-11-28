using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Filter
{
    public class LoginFilter : IFilter
    {
        public bool IsLogged(String token)
        {
            return token.Equals("secret_auth");
        }
    }
}
