using APSmartHome.Business.ExternalServices.APSmartHomeCore.BusinessObject;
using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore
{
    public class APSmartHomeCoreService : IAPSmartHomeCoreService
    {
        private ExternalService.IAPSmartHomeCoreTcpService apSmartCoreTcp;
        private ExternalService.IAPSmartHomeCoreService apSmartCoreApi;

        public APSmartHomeCoreService(string baseApiAddress)
        {
            Cache.BaseRestAddress = baseApiAddress;
            apSmartCoreTcp = new ExternalService.APSmartHomeCoreTcpService();
            apSmartCoreApi = new ExternalService.APSmartHomeCoreService();
        }

        public async Task<bool> SendCommand(BusinessObject.SendRequestModel model)
        {
            try
            {
                var res = await apSmartCoreTcp.ConnectAndSendCommand(
                    model.IPAddress,
                    model.Port,
                    model.ClientID,
                    model.UserName,
                    model.Pass,
                    model.RequestData);

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> SendSecureCommand(BusinessObject.SendRequestModel model)
        {
            try
            {
                var res = await apSmartCoreTcp.SecureConnectAndSendCommand(
                    model.IPAddress,
                    model.Port,
                    model.ClientID,
                    model.UserName,
                    model.Pass,
                    model.RequestData);

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ParkingTriggerResultModel> TriggerParkingApi(ParkingTriggerRequestModel model)
        {
            try
            {
                var res = await apSmartCoreApi.TriggerParking(model);

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
