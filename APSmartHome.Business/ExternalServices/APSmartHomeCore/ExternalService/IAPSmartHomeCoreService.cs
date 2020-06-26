using APSmartHome.Business.ExternalServices.APSmartHomeCore.BusinessObject;
using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System.Threading.Tasks;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalService
{
    public interface IAPSmartHomeCoreService
    {
        Task<ParkingTriggerResultModel> TriggerParking(ParkingTriggerRequestModel model);
    }
}