using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class StateObserver : Observer
    {
        public Form1 Form { get; set; }
        public Robot Robot { get; set; }

        public void Update()
        {
            ITransactionState state = Robot.State;
            Form.updateState(state);
        }
    }
}
