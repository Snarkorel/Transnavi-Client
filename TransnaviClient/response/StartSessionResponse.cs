using Newtonsoft.Json;

namespace transnavi.client.response
{
    public class StartSessionResponseResult
    {
        [JsonProperty("sid")]
        public string Sid { get; set; }
    }

    public class StartSessionResponse : Response
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }
        [JsonProperty("result")]
        public StartSessionResponseResult Result { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
