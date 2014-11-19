using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    [DataContract]
    public class BrockerTO
    {
        public BrockerTO(String name = "", int id = -1)
        {
            Name = name;
            ID = id;
        }

        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public String Name
        {
            get;
            set;
        }

    }
}
