using HTTP.Server;
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
        private ViewHelper mViewHelper;

        public DispatcherView(ViewHelper vh)
        {
            mViewHelper = vh;
        }

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
                    view = new TransactionView(mViewHelper);
                    break;
                case "investors":
                    view = new InvestorView(mViewHelper);
                    break;
                case "composite":
                    view = new CompositeView(mViewHelper);
                    break;
                case "login":
                    view = new LoginView(mViewHelper);
                    break;
                default:
                    break;
            }

            return view;
        }
    }
}
