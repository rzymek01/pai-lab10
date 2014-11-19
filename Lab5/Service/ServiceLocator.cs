using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Service
{
    public class ServiceLocator
    {
        static public Object GetService(String id) {
            switch (id)
            {
                case "investors":
                    var service = new ServiceReference1.Service1Client();
                    return service;

                default:
                    throw new Exception("Unrecognized service: " + id);
            }
        }
    }
}
