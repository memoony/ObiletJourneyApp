using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObiletJourney.Business.Interfaces;
using ObiletJourney.Core.Entities.Bus;
using ObiletJourney.Core.Entities.Session;
using ObiletJourney.Web.Models;
using System.Diagnostics;
using System.Text;

namespace ObiletJourney.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISessionService _sessionService;
        private readonly IBusService _busService;

        private string _sessionId;
        private string _deviceId;

        public HomeController(IHttpContextAccessor httpContextAccessor, ISessionService sessionService, IBusService busService)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionService = sessionService;
            _busService = busService;

            if (_httpContextAccessor.HttpContext != null)
            {
                ISession session = _httpContextAccessor.HttpContext.Session;

                //? Session bilgisi alınıyor.
                if (session.TryGetValue("SessionId", out var sessionIdBytes))
                {
                    _sessionId = Encoding.UTF8.GetString(sessionIdBytes);
                }
                if (session.TryGetValue("DeviceId", out var deviceIdBytes))
                {
                    _deviceId = Encoding.UTF8.GetString(deviceIdBytes);
                }

                //? Session'da bu bilgiler yok ise GetSessionAsync metodu ile session bilgisi alınıp kaydediliyor.
                if (string.IsNullOrEmpty(_sessionId) || string.IsNullOrEmpty(_deviceId))
                {
                    var sessionResult = _sessionService.GetSessionAsync();

                    if (sessionResult.Result.Data != null && sessionResult.Result.Status == "Success" && sessionResult.Result.Data is JObject dataObject)
                    {
                        if (dataObject.TryGetValue("session-id", out var sessionIdToken))
                        {
                            _sessionId = sessionIdToken.ToString();
                        }

                        if (dataObject.TryGetValue("device-id", out var deviceIdToken))
                        {
                            _deviceId = deviceIdToken.ToString();
                        }
                    }
                }
            }
        }

        public IActionResult Index()
        {
            var busLocations = _busService.GetBusLocationsAsync(_sessionId, _deviceId);

            List<SelectListItem> busLocationList = new();

            foreach (BusLocationResponse busLocation in busLocations.Result)
            {
                busLocationList.Add(new SelectListItem
                {
                    Text = busLocation.Name,
                    Value = busLocation.Id.ToString()
                });
            }

            ViewBag.BusLocationList = new SelectList(busLocationList, "Value", "Text");

            return View();
        }

        public IActionResult BusJourney(int originId, int destinationId, DateTime departureDate)
        {
            Data data = new()
            {
                OriginId = originId,
                DestinationId = destinationId,
                DepartureDate = departureDate
            };

            Task<List<BusJourneyResponse>> busJourneys = _busService.GetBusJourneysAsync(data, _sessionId, _deviceId);

            return View(busJourneys.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}