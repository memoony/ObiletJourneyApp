using Newtonsoft.Json;

namespace ObiletJourney.Core.Entities.Session
{
    public class SessionResponse
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        [JsonProperty("affiliate")]
        public string Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("ip-country")]
        public string IpCountry { get; set; }
    }
}
