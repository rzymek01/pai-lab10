using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Filter
{
    public class FilterManager
    {
        private LoginFilter mLoginFilter;


        public FilterManager()
        {
            mLoginFilter = new LoginFilter();
        }

        public bool checkFilters(String token)
        {

            return mLoginFilter.IsLogged(token);
        }
    }
}
