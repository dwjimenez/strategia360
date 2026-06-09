using DFast.Common.Http.Src;
using DFast.Seguridad.Api.Models;
using Docufy.Seguridad.Api.DTOs;

namespace DFast.Seguridad.Api.Proxy
{
    public class NotificacionService : INotificacionService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClient _httpClient;
        private readonly ILogger<NotificacionService> _logger;

        public NotificacionService(IConfiguration configuration, IHttpClient httpClient, ILogger<NotificacionService> logger)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _logger = logger;
        }

        public  async void SendMail(Usuario usuario,string password)
        {

            List<string> listaMails = new();
            listaMails.Add(usuario.Email);
            
            List<string> listaCampos = new();
            listaCampos.Add(usuario.Key);
            listaCampos.Add(password);

            var message = new MessageGeneral(listaMails, "CODIGO DE SEGURIDAD", usuario.Sistema, "forget-password.htm", listaCampos);


            string uri = _configuration["proxy:urlNotificacion"] + "api/notification/sendmail";
            var response = await _httpClient.PostAsync(uri, message);
            //_httpClient.PostAsync(uri, message);

            // Deserializar la cadena en un objeto del tipo deseado ejemplo
            //BaseResponse data = JsonConvert.DeserializeObject<BaseResponse>(await response.Content.ReadAsStringAsync());
            //MessageGeneral midato = JsonConvert.DeserializeObject<MessageGeneral>(data.data.ToString());

            response.EnsureSuccessStatusCode();


        }

        //public async void SendPush(MessagePush messagepush)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Post in AuthController with {0}", "messagepush");
        //        //busco al usuario y saco el token
        //        string uri = _configuration["proxy:urlNotificacion"] + "api/SenderPush/enviarpush";
        //        var response = await _httpClient.PostAsync(uri, messagepush);
        //        _logger.LogInformation("Post in AuthController with {0}", "messagepush");
        //        response.EnsureSuccessStatusCode();
        //    }
        //    catch (HttpRequestException httpEx)
        //    {
        //        // Manejo específico de errores relacionados con la solicitud HTTP
        //        _logger.LogError(httpEx, "Error sending push notification to {0}. HTTP error occurred.", _configuration["proxy:urlNotificacion"]);
        //        throw; // Puedes volver a lanzar la excepción si necesitas que se propague
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo general de errores
        //        _logger.LogError(ex, "An unexpected error occurred while sending push notification.");
        //        throw; // Lanza la excepción para que se maneje en niveles superiores

        //    }
            
        //}

    }
}