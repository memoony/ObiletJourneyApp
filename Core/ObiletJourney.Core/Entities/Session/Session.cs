using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ObiletJourney.Core.Entities.Session
{
    public class Session
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("browser")]
        public Browser Browser { get; set; }

        //? Dokümantasyonda Application olarak geçiyor fakat Postman'den gönderilen modelde Browser yer aldığı için yorum satırına alındı.
        //public Application Application { get; set; }
    }

    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }
    }

    public class Browser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    //public class Application
    //{
    //    public string Version { get; set; }

    //    [JsonPropertyName("equipment-id")]
    //    public string EquipmentId { get; set; }
    //}
}
