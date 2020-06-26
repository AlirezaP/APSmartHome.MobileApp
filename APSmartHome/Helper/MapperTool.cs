using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.Helper
{
  public  class MapperTool
    {
        public static string MapIcon(string iconName)
        {
            return Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP ? $"Images/{iconName}.png" : iconName;
        }
    }
}
