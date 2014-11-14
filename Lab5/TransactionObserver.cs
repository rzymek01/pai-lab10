using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class TransactionObserver : Observer
    {
        public GUI Gui { get; set; }
        public Robot Robot { get; set; }
        
        public void Update()
        {
            TransactionTO t = Gui.LastTransaction;
            Robot.RegistryNewTransaction(t);
        }
    }
}
