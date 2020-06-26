using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Certificates;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace APSmartHome.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();


            // For UWP apps:
            MQTTnet.Implementations.MqttTcpChannel.CustomIgnorableServerCertificateErrorsResolver = o =>
            {
                if (o.Server == "server_with_revoked_cert")
                {
                    return new[] { ChainValidationResult.Revoked };
                }
                var a = ChainValidationResult.Revoked;
                return new ChainValidationResult[0];
            };



            LoadApplication(new APSmartHome.App());


        }
    }
}
