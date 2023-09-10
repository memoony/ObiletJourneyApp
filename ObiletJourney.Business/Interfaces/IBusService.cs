using ObiletJourney.Core.Entities.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletJourney.Business.Interfaces
{
    public interface IBusService
    {
        Task<List<BusLocationResponse>> GetBusLocationsAsync(string sessionId, string deviceId);

        Task<List<BusJourneyResponse>> GetBusJourneysAsync(Data data, string sessionId, string deviceId);
    }
}
