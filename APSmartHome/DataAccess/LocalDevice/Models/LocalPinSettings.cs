using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.DataAccess.LocalDevice.Models
{
    public class LocalPinSettings
    {
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public long ID { get; set; }

        public string Name { get; set; }

        public string PinsInfoJson { get; set; }



        [SQLite.Ignore]
        public PinInfo[] PinsInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(PinsInfoJson))
                {
                  return  Newtonsoft.Json.JsonConvert.DeserializeObject<PinInfo[]>(PinsInfoJson);
                }

                return null;
            }
            set
            {
                if (value!=null)
                {
                    PinsInfoJson = Newtonsoft.Json.JsonConvert.SerializeObject(value);
                }
            }
        }
    }
}
