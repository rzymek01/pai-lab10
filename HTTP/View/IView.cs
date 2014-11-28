using HTTP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.View
{
    public abstract class IView
    {
        public ViewHelper Helper
        {
            get;
            protected set;
        }

        public IView(ViewHelper vh)
        {
            Helper = vh;
        }

        abstract public String Render();
    }
}
