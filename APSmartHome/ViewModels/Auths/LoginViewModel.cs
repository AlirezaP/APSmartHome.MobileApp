using APSmartHome.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APSmartHome.ViewModels.Auths
{
    public class LoginViewModel : BaseViewModel
    {
        private string pass;
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }


        public ICommand LoginUser => new Command(async () => await Login());
        public ICommand BioLoginUser => new Command(async () => await BioLogin());

        public LoginViewModel()
        {

        }

        private async Task Login()
        {
            try
            {
                if (string.IsNullOrEmpty(Pass))
                {
                    await Helper.Dialogs.ShowBasicMessage("کلمه عبور الزامی می باشد!");
                    return;
                }

                string t = await Helper.Security.GetSecureString("AppPssAPSmart");
                if (Pass != t)
                {
                    await Helper.Dialogs.ShowBasicMessage("کلمه عبور صحیح نمی باشد!");
                    return;
                }

                //await Task.Delay(1000);
                //Helper.Dialogs.Loading();
                //await Task.Delay(200);

                await LoadSettings();
                App.Current.MainPage = new Views.MainPage();
            }
            catch (Exception ex)
            {
               await Helper.Dialogs.ShowBasicMessage("خطا!");
            }
        }

        private async Task BioLogin()
        {
            try
            {
                var authRes = await Helper.Security.BioAuthentication();

                if (!authRes)
                {
                   await Helper.Dialogs.ShowBasicMessage("دسترسی غیر مجاز!");
                    return;
                }

                //await Task.Delay(1000);
                //Helper.Dialogs.Loading();
                //await Task.Delay(200);
                //Helper.Dialogs.HideLoading();

                await LoadSettings();
                App.Current.MainPage = new Views.MainPage();

            }
            catch (Exception ex)
            {
               await Helper.Dialogs.ShowBasicMessage("خطا!");
            }
        }

        private async Task LoadSettings()
        {
            DBFactory db = new DBFactory();
            var current = (await db.GetGlobalSettingsDB().GetGlobalSettingAsync()).FirstOrDefault();
            if (current != null)
            {
                APSmartHome.Settings.LocalIPAddressDevice = current.LocalIPAddress;
                APSmartHome.Settings.OverInternet = current.OverInternet;

                if (!string.IsNullOrEmpty(current.APIKey))
                {
                    foreach (char ch in current.APIKey)
                        APSmartHome.Settings.ApiKey.AppendChar(ch);
                }
            }
        }
    }
}
