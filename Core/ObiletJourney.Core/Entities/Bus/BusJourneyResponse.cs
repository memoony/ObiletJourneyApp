using Newtonsoft.Json;

namespace ObiletJourney.Core.Entities.Bus
{
    public class BusJourneyResponse
    {
        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }
    }

    public class Journey
    {
        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime? Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime? Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }
    }
}
