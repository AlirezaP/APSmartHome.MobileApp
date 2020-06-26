using APSmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APSmartHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageItem : FlexLayout
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public HomePageItem()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var item = ((Models.Item)BindingContext);

            await RootPage.NavigateFromMenu(item.IdPage);

        }

        //var item = ((Models.sms.SmsItemsModel)BindingContext);

        //if (item.ActionName == "LastPosition")
        //    await Helper.SmsHelper.SendSms(Business.Settings.SmsCLastLocation, "");

        //if (item.ActionName == "RelOn1")
        //    await Helper.SmsHelper.SendSms(Business.Settings.RelOn1, "");

        //if (item.ActionName == "RelOff1")
        //    await Helper.SmsHelper.SendSms(Business.Settings.RelOff1, "");

        //if (item.ActionName == "RelOn2")
        //    await Helper.SmsHelper.SendSms(Business.Settings.RelOn2, "");

        //if (item.ActionName == "RelOff2")
        //    await Helper.SmsHelper.SendSms(Business.Settings.RelOff2, "");
    }
}