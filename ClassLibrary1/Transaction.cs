using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    #region "business object"

    [DataContract]
    public class Transaction
    {
        public Transaction(float price = 0.0f, int amount = 0, int id = -1)
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

        //public override bool Equals(object obj)
        //{
        //    if (obj == null) return false;
        //    Transaction objAsPart = obj as Transaction;
        //    if (objAsPart == null) return false;
        //    else return Equals(objAsPart);
        //}
        //public override int GetHashCode()
        //{
        //    return ID;
        //}
        //public bool Equals(Transaction other)
        //{
        //    if (other == null) return false;
        //    return (this.Equals(other.PartId));
        //}
    }
    #endregion
}
