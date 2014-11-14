using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class GUI : Observable
    {
        public GUI()
        {

        }

        public void RegistryNewTransaction(TransactionTO t)
        {
            LastTransaction = t;
            Notify();
        }

        public TransactionTO LastTransaction { get; set; }
    }
}
