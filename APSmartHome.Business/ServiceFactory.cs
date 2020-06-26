using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.Business
{
   public class ServiceFactory
    {
        public ServiceFactory()
        {

        }

        public ExternalServices.APSmartHomeCore.IAPSmartHomeCoreService GetAPSmartHomeCoreService(string baseAddress)
        {
            return new ExternalServices.APSmartHomeCore.APSmartHomeCoreService(baseAddress);
        }


    }
}
