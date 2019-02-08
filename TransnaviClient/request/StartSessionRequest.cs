using Newtonsoft.Json;

namespace TransnaviClient.request
{
    public class StartSessionRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }

        public StartSessionRequest()
        {
            Id = 1;
            JsonRpc = "2.0";
            Method = "startSession";
        }
    }
}
