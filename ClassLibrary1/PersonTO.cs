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
    public class PersonTO
    {
        public PersonTO(String firstname = "", String surname = "", int id = -1)
        {
            Firstname = firstname;
            Surname = surname;
            ID = id;
        }

        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public String Firstname
        {
            get;
            set;
        }

        [DataMember]
        public String Surname
        {
            get;
            set;
        }
    }
}
