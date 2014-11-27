using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Service
{
    public class ServiceLocator
    {
        public const String INVESTORS_SERVICE = "investors";
        public const String FACADE_SERVICE = "facade";

        private ServiceReference1.Service1Client mInvestorsService;
        private FacadeService.Service1Client mFacadeService;

        static private ServiceLocator cInstance;

        static public ServiceLocator Instance
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                if (null == cInstance)
                {
                    cInstance = new ServiceLocator();
                }
                return cInstance;
            }
        }

        public Object GetService(String id) {
            switch (id)
            {
                case INVESTORS_SERVICE:
                    if (null == mInvestorsService)
                    {
                        mInvestorsService = (ServiceReference1.Service1Client)CreateService(id);
                    }
                    return mInvestorsService;

                case FACADE_SERVICE:
                    if (null == mFacadeService)
                    {
                        mFacadeService = (FacadeService.Service1Client)CreateService(id);
                    }
                    return mFacadeService;

                default:
                    throw new Exception("Unrecognized service: " + id);
            }
        }

        private Object CreateService(String id)
        {
            switch (id)
            {
                case INVESTORS_SERVICE:
                    return new ServiceReference1.Service1Client();
                case FACADE_SERVICE:
                    return new FacadeService.Service1Client();
                default:
                    throw new Exception("Unrecognized service: " + id);
            }
        }
        private ServiceLocator()
        {

        }
    }
}
