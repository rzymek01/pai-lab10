using HTTP.Dispatcher;
using HTTP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP.Controller
{
    public class FrontController
    {
        private DispatcherView mDispatcher;
        private ViewHelper mViewHelper;

        public FrontController(ViewHelper vh)
        {
            mViewHelper = vh;
            mDispatcher = new DispatcherView(mViewHelper);
        }

        public String Process(String path)
        {
            var output = mDispatcher.Route(path);
            return output;
        }
    }
}
