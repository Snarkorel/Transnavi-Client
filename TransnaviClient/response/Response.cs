using Newtonsoft.Json;

namespace transnavi.client.response
{
    public class Response
    {
        [JsonProperty("id")]
        public int ResponseId { get; set; }
        [JsonProperty("jsonrpc")]
        public string JsonRpcVersion { get; set; }

        protected Response() { }
    }
}
