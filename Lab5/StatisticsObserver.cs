using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class StatisticsObserver : Observer
    {
        public Form1 Form { get; set; }
        public Robot Robot { get; set; }

        public void Update()
        {
            Statictics stats = Robot.Stats;
            Form.updateStats(stats);
        }
    }
}
