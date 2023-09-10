using Newtonsoft.Json;
using ObiletJourney.Business.Interfaces;
using ObiletJourney.Core.Entities;
using ObiletJourney.Core.Entities.Bus;
using ObiletJourney.Core.Entities.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletJourney.Business.Services
{
    public class BusService : IBusService
    {
        private readonly IObiletAPIService _obiletAPIService;

        public BusService(IObiletAPIService obiletAPIService)
        {
            _obiletAPIService = obiletAPIService;
        }

        public async Task<List<BusLocationResponse>> GetBusLocationsAsync(string sessionId, string deviceId)
        {
            try
            {
                BusLocation busLocation = new()
                {
                    DeviceSession = new DeviceSession
                    {
                        SessionId = sessionId,
                        DeviceId = deviceId
                    }
                };

                BaseResponse? result = JsonConvert.DeserializeObject<BaseResponse>(await _obiletAPIService.PostAsync<BusLocation>("/location/getbuslocations", busLocation));

                return JsonConvert.DeserializeObject<List<BusLocationResponse>>(result.Data.ToString());
            }
            catch (Exception ex)
            {

                throw new Exception("Otobüs lokasyonları alınırken bir hata oluştu!", ex);
            }
        }

        public async Task<List<BusJourneyResponse>> GetBusJourneysAsync(Data data, string sessionId, string deviceId)
        {
            try
            {
                BusJourney busJourney = new()
                {
                    DeviceSession = new DeviceSession
                    {
                        SessionId = sessionId,
                        DeviceId = deviceId
                    },
                    Data = data,
                };

                BaseResponse? result = JsonConvert.DeserializeObject<BaseResponse>(await _obiletAPIService.PostAsync<BusJourney>("/journey/getbusjourneys", busJourney));

                return JsonConvert.DeserializeObject<List<BusJourneyResponse>>(result.Data.ToString()).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Otobüs seferleri alınırken bir hata oluştu!", ex);
            }
        }
    }
}
