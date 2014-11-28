using HTTP.Dispatcher;
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

        public FrontController()
        {
            mDispatcher = new DispatcherView();
        }

        public String Process(String path)
        {
            var output = mDispatcher.Route(path);
            return output;
        }
    }
}
