using Newtonsoft.Json;
using ObiletJourney.Core.Entities.Session;

namespace ObiletJourney.Core.Entities
{
    public class BaseRequest
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";
    }
}
