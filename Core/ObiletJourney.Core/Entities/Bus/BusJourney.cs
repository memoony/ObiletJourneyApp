using Newtonsoft.Json;

namespace ObiletJourney.Core.Entities.Bus
{
    public class BusJourney : BaseRequest
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
