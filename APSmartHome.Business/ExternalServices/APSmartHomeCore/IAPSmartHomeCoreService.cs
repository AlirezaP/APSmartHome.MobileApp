using APSmartHome.Business.ExternalServices.APSmartHomeCore.BusinessObject;
using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System.Threading.Tasks;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore
{
    public interface IAPSmartHomeCoreService
    {
        Task<bool> SendCommand(SendRequestModel model);
        Task<bool> SendSecureCommand(BusinessObject.SendRequestModel model);
        Task<ParkingTriggerResultModel> TriggerParkingApi(ParkingTriggerRequestModel model);
    }
}