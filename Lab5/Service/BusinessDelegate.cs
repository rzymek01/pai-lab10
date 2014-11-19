using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Service
{
    abstract public class BusinessDelegate<T>
    {
        protected T Service
        {
            get; set;
        }

        public String SERVICE_ID
        {
            get;
            private set;
        }

        public BusinessDelegate(String serviceId)
        {
            SERVICE_ID = serviceId;

            reconnect();
        }

        protected void reconnect()
        {
            Service = (T)ServiceLocator.GetService(SERVICE_ID);
        }
    }
}
