using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class TransportTypeRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("ok_id")]
        public string OkId { get; set; } //I don't know, what is this
    }

    public class TransportTypeRequest : Request
    {
        private const string _method = "getTransTypeTree";
        [JsonProperty("params")]
        public TransportTypeRequestParams Params { get; set; }

        /// <summary>
        /// Get tree of all routes and all transport types (trolleybus, bus, tram)
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        public TransportTypeRequest(int requestId, string sessionId) : base(requestId, _method)
        {
            Params = new TransportTypeRequestParams
            {
                OkId = string.Empty,
                SessionId = sessionId
            };
        }
    }
}
