using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APSmartHome.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasicSettingPage : ContentPage
    {
        public BasicSettingPage()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            //var vm = ((ViewModels.Settings.SettingsViewModel)(this.BindingContext));
            //vm.OverInternet = e.Value;
        }
    }
}