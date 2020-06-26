using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore.BusinessObject
{
    public enum ActionCode
    {
        Open = 1,
        Close = 2
    }
    public class ParkingTriggerRequestModel
    {
        public string ClientID { get; set; }
        public int ActionCode { get; set; }
        public long Tick { get; set; }

        public long Seq { get; set; }

        public string Tcode { get; set; }
    }
}
