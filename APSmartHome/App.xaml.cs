using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using APSmartHome.Services;
using APSmartHome.Views;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace APSmartHome
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;


            DependencyService.Register<MockDataStore>();
            // MainPage = new MainPage();

            if (string.IsNullOrEmpty(Helper.Security.GetSecureString(Settings.FisrtTimeUseKey).GetAwaiter().GetResult()))
            {
                MainPage = new Views.Auths.NewPasswordPage();
                return;
            }

            MainPage = new Views.Auths.LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        //......................................

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
