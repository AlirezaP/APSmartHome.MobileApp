using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APSmartHome.ViewModels.Auths
{
    class NewPasswordViewModel : BaseViewModel
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

        private string passConfirm;
        public string PassConfirm
        {
            get
            {
                return passConfirm;
            }
            set
            {
                passConfirm = value;
                OnPropertyChanged(nameof(PassConfirm));
            }
        }


        public ICommand SavePassword => new Command(async () => await SavePass());

        public NewPasswordViewModel()
        {

        }

        private async Task SavePass()
        {
            if (string.IsNullOrEmpty(Pass)
                || string.IsNullOrEmpty(passConfirm))
            {
               await Helper.Dialogs.ShowBasicMessage("کلمه عبور الزامی می باشد!");
                return;
            }

            if (Pass != PassConfirm)
            {
               await Helper.Dialogs.ShowBasicMessage("کلمه عبور با تکرار آن برابر نمی باشد!");
                return;
            }

            await Helper.Security.SaveSecureString("AppPssAPSmart", Pass);
            await Helper.Security.SaveSecureString(APSmartHome.Settings.FisrtTimeUseKey, "112236654");

            App.Current.MainPage = new Views.Auths.LoginPage();
        }
    }
}
