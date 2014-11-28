using HTTP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.View
{
    public class LoginView : IView
    {
        public LoginView(ViewHelper vh)
            : base(vh)
        {
 
        }

        override public string Render()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<html><head>");
            result.Append("<title>Composite View</title>");
            result.Append("<meta charset=\"utf-8\"/>");
            result.Append("</head><body>");
            result.Append("<h1>Logowanie</h1>");
            result.Append("<form method=\"get\" action=\"auth\">");
            result.Append("Login: <input name=\"login\"><br/>");
            result.Append("Hasło: <input name=\"passwd\" type=\"password\"><br/>");
            result.Append("<input type=\"submit\" value=\"Zaloguj\">");
            result.Append("");
            result.Append("");
            result.Append("");
            result.Append("");
            result.Append("</form>");
            result.Append("</body></html>");

            return result.ToString();
        }
    }
}
