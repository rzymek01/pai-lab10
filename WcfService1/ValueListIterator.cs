using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public interface ValueListIterator<T>
    {
        int GetSize();
        List<T> GetPage(int pageNo, int pageSize);
    }
}