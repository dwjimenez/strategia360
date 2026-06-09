using DFast.Seguridad.Api.Models;

namespace DFast.Seguridad.Api.Proxy
{
    public interface INotificacionService
    {
        void SendMail(Usuario request, string password);
        //void SendPush(MessagePush messagepush);
    }
}
