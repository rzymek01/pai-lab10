using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    #region "business object"
    public class Transaction
    {
        public Transaction(float price = 0.0f, int amount = 0, int id = -1)
        {
            Price = price;
            Amount = amount;
            ID = id;
        }

        public float Price
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }
    }
    #endregion
}
