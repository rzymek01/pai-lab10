using HTTP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using ClassLibrary1;

namespace HTTP.View
{
    public class CompositeView : IView
    {
        public CompositeView(ViewHelper vh) : base(vh)
        {
 
        }

        override public string Render()
        {
            String token = Helper.Token;
            Console.WriteLine("CompositeView: token: " + token);

            var valueHolder = new BrockerTO();
            var valueHolder2 = new BrockerTO();

            fetchFirstData(token, valueHolder).Wait();
            fetchSecondData(token, valueHolder2).Wait();

            StringBuilder result = new StringBuilder();
            result.Append("<html><head>");
            result.Append("<title>Composite View</title>");
            result.Append("<meta charset=\"utf-8\"/>");
            result.Append("</head><body>");
            result.Append("<h1>Widok złożony</h1>");
            result.Append("<h2>Transakcja</h2>");
            result.Append(valueHolder.Name);
            result.Append("<h2>Broker</h2>");
            result.Append(valueHolder2.Name);
            result.Append("</body></html>");

            return result.ToString();
        }

        static async protected Task fetchFirstData(String token, BrockerTO valueHolder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8081");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/web/get?token=" + token);
                if (response.IsSuccessStatusCode)
                {
                    String output = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("output: " + output);
                    valueHolder.Name = output;
                }
            }
        }

        static async protected Task fetchSecondData(String token, BrockerTO valueHolder)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8082");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/web/get?token=" + token);
                if (response.IsSuccessStatusCode)
                {
                    String output = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("output#2: " + output);
                    valueHolder.Name = output;
                }
            }
        }
    }
}
