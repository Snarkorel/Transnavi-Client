using Newtonsoft.Json;

namespace TransnaviClient.response
{
    public class StartSessionResponseResult
    {
        [JsonProperty("sid")]
        public string Sid { get; set; }
    }

    public class StartSessionResponse
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }
        [JsonProperty("result")]
        public StartSessionResponseResult Result { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
