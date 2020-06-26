
using APSmartHome.Business.Common;
using APSmartHome.Business.ExternalServices.APSmartHomeCore.BusinessObject;
using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalService
{
    public class APSmartHomeCoreService : IAPSmartHomeCoreService
    {


        private string parkingTrigger = "api/Parkings/Trigger";


        private string serverpublicKey = @"ServerPublicKey Base64 Must Be Here!!!";


        private string pKey = @"private Device Key Base64 Must Be Here!!!";

        private IRestCommunication rest = new RestCommunication(Cache.BaseRestAddress);

        public APSmartHomeCoreService()
        {
            var myRsaPublic = RSA.Create();

        }

        public async Task<ParkingTriggerResultModel> TriggerParking(ParkingTriggerRequestModel model)
        {
            try
            {
                byte[] jsonData = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(model));
                var serverrsaHelper = Helper.SecurityHelper.GetRSAProviderFromPemFile(serverpublicKey, false);
                var clientrsaHelper = Helper.SecurityHelper.GetRSAProviderFromPemFile(pKey, true);

                var signData = clientrsaHelper.SignData(jsonData, new SHA256CryptoServiceProvider());
                var secureData = serverrsaHelper.Encrypt(jsonData, false);

                var secureReq = new ParkingTriggerSecureRequestModel()
                {
                    Data = Convert.ToBase64String(secureData),
                    Sign = Convert.ToBase64String(signData)
                };

                return await rest.PostRequest<ParkingTriggerResultModel>(parkingTrigger, secureReq, false);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
