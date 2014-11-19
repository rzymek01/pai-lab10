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
    public class TransactionTO
    {
        public TransactionTO(float price = 0.0f, int amount = 0, int id = -1)
        {
            Price = price;
            Amount = amount;
            ID = id;
        }

        [DataMember]
        public float Price
        {
            get;
            set;
        }

        [DataMember]
        public int Amount
        {
            get;
            set;
        }

        [DataMember]
        public int ID
        {
            get;
            set;
        }
    }
}
