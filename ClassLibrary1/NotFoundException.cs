using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibrary1
{
    [Serializable]
    [DataContract]
    public class NotFoundException
    {
        public NotFoundException(String message = "")
        {
            Message = message;
        }

        [DataMember]
        public String Message
        {
            get;
            set;
        }
    }
}
