using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ObiletJourney.Business.Interfaces;
using ObiletJourney.Core.Entities;
using ObiletJourney.Core.Entities.Session;
using ObiletJourney.Core.Helpers;

namespace ObiletJourney.Business.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IObiletAPIService _obiletAPIService;

        public SessionService(IHttpContextAccessor httpContextAccessor, IObiletAPIService obiletAPIService)
        {
            _httpContextAccessor = httpContextAccessor;
            _obiletAPIService = obiletAPIService;
        }

        public async Task<BaseResponse> GetSessionAsync()
        {
            try
            {
                string ipAddress = await IPHelper.GetIpAddressAsync();
                
                string userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();
                string browserName = UserAgentHelper.GetBrowserName(userAgent);
                string browserVersion = UserAgentHelper.GetBrowserVersion(userAgent);

                Session session = new()
                {
                    Type = 1, //? Postman collection'da 1 olarak gönderildiği için güncellendi.
                    Connection = new Connection
                    {
                        IpAddress = ipAddress,
                        Port = "5117"
                    },
                    Browser = new Browser
                    {
                        Name = browserName,
                        Version = browserVersion
                    }
                };

                BaseResponse? result = JsonConvert.DeserializeObject<BaseResponse>(await _obiletAPIService.PostAsync<Session>("/client/getsession", session));

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new BaseResponse { Message = "Session bilgisi bulunamadı!" };
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Session bilgisi alınırken bir hata oluştu!", ex);
            }
        }
    }
}
