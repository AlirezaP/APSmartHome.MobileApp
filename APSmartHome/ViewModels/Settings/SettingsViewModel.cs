using APSmartHome.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APSmartHome.ViewModels.Settings
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool overInternet = false;
        public bool OverInternet
        {
            get
            {
                return overInternet;
            }
            set
            {
                overInternet = value;
                OnPropertyChanged(nameof(OverInternet));
            }
        }

        private string localIPAddress = "192.168.1.70";
        public string LocalIPAddress
        {
            get
            {
                return localIPAddress;
            }
            set
            {
                localIPAddress = value;
                OnPropertyChanged(nameof(LocalIPAddress));
            }
        }


        private string apiKey = "";
        public string ApiKey
        {
            get
            {
                return apiKey;
            }
            set
            {
                apiKey = value;
                OnPropertyChanged(nameof(ApiKey));
            }
        }

        public ICommand ISaveAction => new Command(async () => await SaveAction());


        private DBFactory db;
        private DataAccess.LocalDevice.Models.GlobalSetting current = null;
        public SettingsViewModel()
        {
            db = new DBFactory();
            Task.Run(() => (current = db.GetGlobalSettingsDB().GetGlobalSettingAsync().Result.FirstOrDefault())).Wait();
            if (current != null)
            {
                LocalIPAddress = current.LocalIPAddress;
                OverInternet = current.OverInternet;
                ApiKey = current.APIKey;
            }
        }

        private async Task SaveAction()
        {
            try
            {
                APSmartHome.Settings.LocalIPAddressDevice = LocalIPAddress;
                APSmartHome.Settings.OverInternet = OverInternet;

                APSmartHome.Settings.ApiKey.Clear();

                foreach (char ch in ApiKey)
                    APSmartHome.Settings.ApiKey.AppendChar(ch);



                DBFactory db = new DBFactory();

               // var current = (await db.GetGlobalSettingsDB().GetGlobalSettingAsync()).FirstOrDefault();

                if (current == null)
                {
                    current = new DataAccess.LocalDevice.Models.GlobalSetting
                    {
                        LocalIPAddress = LocalIPAddress,
                        OverInternet = OverInternet,
                        APIKey = ApiKey
                    };
                }
                else
                {
                    current.LocalIPAddress = LocalIPAddress;
                    current.OverInternet = overInternet;
                    current.APIKey = ApiKey;
                }

             
                await db.GetGlobalSettingsDB().SaveGlobalSettingAsync(current);

                Helper.Dialogs.ShowToastMessage("عملیات با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                await Helper.Dialogs.ShowBasicMessage(ex.Message);
            }
        }

    }
}
