using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace APSmartHome
{
  public  class Settings
    {
        internal static string FisrtTimeUseKey = "firstTime";
        internal static int ParkingPinNum = 12;
        internal static bool ParkingPinVal = true;
        internal static int ParkingCommandDuartion = 5000;

        internal static string LocalIPAddressDevice = "192.168.1.70";
        internal static string APIIPAddress = "https://MyVmIPAddressOnInternet";

        internal static string ClientID = "192.168.1.7";

        internal static string DeviceSecret = "MySecretUserName!";

        internal static int DevicePort = 1412;

        internal static string DeviceUserName = "APUser110";

        internal static bool OverInternet = false;

        internal static SecureString ApiKey = new SecureString();

    }
}
