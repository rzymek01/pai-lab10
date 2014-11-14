using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5
{
    public class BuyState : ITransactionState
    {
        public string Name { get; set; }

        public BuyState()
        {
            Name = "Buy";
        }
    }
}
