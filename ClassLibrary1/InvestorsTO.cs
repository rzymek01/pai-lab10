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
    public class InvestorsTO
    {
        public InvestorsTO(List<InvestorCETO> investors = null, List<BrockerTO> brockers = null)
        {
            Investors = investors;
            Brockers = brockers;
        }

        [DataMember]
        public List<InvestorCETO> Investors
        {
            get;
            set;
        }

        [DataMember]
        public List<BrockerTO> Brockers
        {
            get;
            set;
        }
    }
}
