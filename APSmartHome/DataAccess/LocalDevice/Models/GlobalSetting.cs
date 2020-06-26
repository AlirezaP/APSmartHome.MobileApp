using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.DataAccess.LocalDevice.Models
{
   public class GlobalSetting
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int ID { get; set; }
        public bool OverInternet { get; set; }

        public string LocalIPAddress { get; set; }

        public string APIKey { get; set; }
    }
}
