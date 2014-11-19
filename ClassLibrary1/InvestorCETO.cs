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
    public class InvestorCETO
    {
        public InvestorCETO(PersonTO person = null, List<TransactionTO> t = null)
        {
            Person = person;
            Transactions = t;
        }

        [DataMember]
        public PersonTO Person
        {
            get;
            set;
        }

        [DataMember]
        public List<TransactionTO> Transactions
        {
            get;
            set;
        }
    }
}
