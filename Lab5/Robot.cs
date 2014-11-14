using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Robot : Observable
    {
        public ITransactionState State { get; set; }
        public Statictics Stats { get; set; }
        
        public Robot()
        {
            State = new HoldState();
            Stats = new Statictics();
        }


        public void RegistryNewTransaction(TransactionTO t)
        {
            Stats.TotalAmount += t.Amount;

            //
            if (Stats.TotalAmount > 500)
            {
                State = new BuyState();
            }
            else if (Stats.TotalAmount > 1000)
            {
                State = new SellState();
            }

            Notify();
        }
    }
}
