using Newtonsoft.Json;

namespace transnavi.client.request
{
    public abstract class Request
    {
        [JsonProperty("id")]
        public int RequestId { get; set; }
        [JsonProperty("jsonrpc")]
        public string JsonRpcVersion { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }

        public Request(int requestId, string method)
        {
            JsonRpcVersion = "2.0";
            RequestId = requestId;
            Method = method;
        }
    }
}
