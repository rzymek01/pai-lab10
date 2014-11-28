using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Server
{
    public class ViewHelper
    {
        public bool Logged
        {
            get;
            protected set;
        }

        public string Token
        {
            get
            {
                return (Logged) ? "secret_auth" : "";
            }
        }

        public ViewHelper()
        {
            Logged = false;
        }

        public bool Auth(String username, String password)
        {
            Console.WriteLine("in Auth\n");
            if (username.Equals("admin") && password.Equals("1234"))
            {
                Console.WriteLine("in Auth: logged in\n");
                Logged = true;
            }

            return Logged;
        }

        public void Logout()
        {
            Console.WriteLine("in Auth: logged out\n");
            Logged = false;
        }
    }
}
