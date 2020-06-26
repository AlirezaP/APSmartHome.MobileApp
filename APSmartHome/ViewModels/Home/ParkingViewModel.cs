using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace APSmartHome.ViewModels.Home
{
    public class ParkingViewModel : BaseViewModel
    {

        private bool triggerTimerVisibility = false;
        public bool TriggerTimerVisibility
        {
            get
            {
                return triggerTimerVisibility;
            }
            set
            {
                triggerTimerVisibility = value;
                OnPropertyChanged(nameof(TriggerTimerVisibility));
            }
        }

        public ICommand TriggerDoor => new Command(async () => await TriggerParkingDoor());
        
        public ParkingViewModel()
        {

        }

        private async Task TriggerParkingDoor()
        {
            try
            {
                if (TriggerTimerVisibility)
                {
                    return;
                }

                if (!(await Helper.Dialogs.ShowConfirm("سنسور فراخوانی شود؟")))
                {
                    return;
                }

                var password = new System.Net.NetworkCredential(string.Empty, APSmartHome.Settings.ApiKey).Password;

                var srv = new Business.ServiceFactory().GetAPSmartHomeCoreService(APSmartHome.Settings.APIIPAddress);
                CommandModel command = new CommandModel();
                List<PinCommand> pinsAct = new List<PinCommand>();
                pinsAct.Add(new PinCommand
                {
                    PinNumber = APSmartHome.Settings.ParkingPinNum,
                    PinMode = 1,
                    PinVal = APSmartHome.Settings.ParkingPinVal
                });

                command.PinActions = pinsAct.ToArray();
                command.HasReversePinVal = true;
                command.ReversePinVal = false;
                command.DelayForReversePinVal = APSmartHome.Settings.ParkingCommandDuartion;
                command.Tcode = password;
                command.Tick = DateTime.Now.Ticks;
           

                if (APSmartHome.Settings.OverInternet)
                {
                    Business.ServiceFactory fact = new Business.ServiceFactory();
              
                    var internetRes = await fact.GetAPSmartHomeCoreService(APSmartHome.Settings.APIIPAddress).TriggerParkingApi(new Business.ExternalServices.APSmartHomeCore.BusinessObject.ParkingTriggerRequestModel
                    {
                        Tick = DateTime.Now.Ticks,
                        ClientID = APSmartHome.Settings.ClientID,
                        ActionCode = 1,
                        Tcode = password,
                        Seq = 1,

                    });

                    if (internetRes == null || internetRes.Status!=0)
                    {
                        await Helper.Dialogs.ShowBasicMessage("عملیات نا موفق!");
                        return;
                    }
                }

                if (!APSmartHome.Settings.OverInternet)
                {
                    var res = await srv.SendSecureCommand(new Business.ExternalServices.APSmartHomeCore.BusinessObject.SendRequestModel
                    {
                        ClientID = APSmartHome.Settings.ClientID,
                        IPAddress = APSmartHome.Settings.LocalIPAddressDevice,
                        Pass = APSmartHome.Settings.DeviceSecret,
                        Port = APSmartHome.Settings.DevicePort,
                        UserName = APSmartHome.Settings.DeviceUserName,
                        RequestData = new Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects.RequestModel
                        {
                            Topic = "Segment",
                            Commands = new CommandModel[] { command }
                        },

                    });

                    if (!res)
                    {
                        await Helper.Dialogs.ShowBasicMessage("عملیات نا موفق!");
                        return;
                    }
                }

                ShowTriggerTimer();
            }
            catch (Exception ex)
            {
                await Helper.Dialogs.ShowBasicMessage(ex.Message);
            }
        }

        private void ShowTriggerTimer()
        {
            TriggerTimerVisibility = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(APSmartHome.Settings.ParkingCommandDuartion), TimerElapsed);
        }

        private bool TimerElapsed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //put here your code which updates the view
            });
            //return true to keep timer reccurring
            //return false to stop timer

            TriggerTimerVisibility = false;

            Helper.Dialogs.ShowToastMessage("عملیات انجام شد"); ;

            return false;
        }
    }
}
