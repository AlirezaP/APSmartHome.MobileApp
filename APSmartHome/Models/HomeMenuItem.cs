using System;
using System.Collections.Generic;
using System.Text;

namespace APSmartHome.Models
{
    public enum MenuItemType
    {
        Home,
        Parking,
        Test,
        Setting,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
