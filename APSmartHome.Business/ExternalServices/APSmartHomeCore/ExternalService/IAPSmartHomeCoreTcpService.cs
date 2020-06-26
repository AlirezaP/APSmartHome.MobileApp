using APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalServiceObjects;
using System.Threading.Tasks;

namespace APSmartHome.Business.ExternalServices.APSmartHomeCore.ExternalService
{
    public interface IAPSmartHomeCoreTcpService
    {
        Task<bool> ConnectAndSendCommand(string ipAddress, int port, string clientID, string userName, string secret, RequestModel model);
        Task<bool> SecureConnectAndSendCommand(string ipAddress, int port, string clientID, string userName, string secret, RequestModel model);
    }
}