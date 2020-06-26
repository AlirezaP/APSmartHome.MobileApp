using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects
{
   public class RequestModel
    {
        public string Topic { get; set; }
        public ExternalServiceObjects.CommandModel[] Commands { get; set; }
    }
}
