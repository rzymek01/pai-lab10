using HTTP.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Dispatcher
{
    public class DispatcherView
    {
        public String Route(String path)
        {
            String name = path;
            IView view = getView(name);
            if (null != view)
            {
                return view.Render();
            }
            return "";
        }

        protected IView getView(String name)
        {
            IView view = null;
            switch (name)
            {
                case "transactions":
                    view = new TransactionView();
                    break;
                case "investors":
                    view = new InvestorView();
                    break;
                default:
                    break;
            }

            return view;
        }
    }
}
