using DFast.Common.Types;
using Docufy.Seguridad.Api.DTOs;
using RestEase;

namespace DFast.Seguridad.Api.Proxy
{
    public interface ISendNotificationService
    {
        [AllowAnyStatusCode]
        [Post("api/notification/sendpush")] 
        Task<BaseResponse> SendPush([Body] MessagePushDto messagepush);
    }
}