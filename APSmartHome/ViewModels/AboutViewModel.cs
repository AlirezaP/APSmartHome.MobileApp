using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace APSmartHome.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await OpenDoor());
        }

        public ICommand OpenWebCommand { get; }


        private async Task OpenDoor()
        {
           // await Browser.OpenAsync("https://xamarin.com");


            //...........................
            // Create TCP based options using the builder.
            var options = new MqttClientOptionsBuilder()
                .WithClientId("APHome Smart @!")
                         .WithTcpServer("APSmartH", 1413)
                //.WithTcpServer("192.168.1.120", 1413)
                .WithCredentials("APUser110", "%#1370AaPp1372*%")
                .WithTls(new MqttClientOptionsBuilderTlsParameters
                {
                    UseTls = true,
                    CertificateValidationCallback = (X509Certificate x, X509Chain y, SslPolicyErrors z, IMqttClientOptions o) =>
                    {
                        // TODO: Check conditions of certificate by using above parameters.
                        return true;
                    }

                })
                .WithCleanSession()
                .Build();


            //.........................
            var mqttClient = new MqttFactory().CreateMqttClient();

            mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                var a = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            });


            await mqttClient.ConnectAsync(options, CancellationToken.None); // Since 3.0.5 with CancellationToken


            //............................
            //Send MSG
            var message = new MqttApplicationMessageBuilder()
               .WithTopic("MyTopic")
               .WithPayload("Hello World")
               .WithExactlyOnceQoS()
               .WithRetainFlag()
               .Build();

            var res = await mqttClient.PublishAsync(message, CancellationToken.None); // Since 3.0.5 with CancellationToken



        }
    }
}