using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.DataAccess
{
   public class DBFactory
    {
        private static DataAccess.LocalDevice.LocalPinSettingsContext localPinSettingsDB;
        private static DataAccess.LocalDevice.GlobalSettingContext globalSettingDB;

        private string dbPathBase = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public DBFactory()
        {

        }

        internal DataAccess.LocalDevice.LocalPinSettingsContext GetLocalDeviceDB()
        {
            if (localPinSettingsDB == null)
            {
                localPinSettingsDB = new DataAccess.LocalDevice.LocalPinSettingsContext(dbPathBase + "\\LocalDDb", "s");
            }

            return localPinSettingsDB;
        }

        internal DataAccess.LocalDevice.GlobalSettingContext GetGlobalSettingsDB()
        {
            if (globalSettingDB == null)
            {
                globalSettingDB = new DataAccess.LocalDevice.GlobalSettingContext(dbPathBase + "\\GlobalDb", "s");
            }

            return globalSettingDB;
        }
    }
}
