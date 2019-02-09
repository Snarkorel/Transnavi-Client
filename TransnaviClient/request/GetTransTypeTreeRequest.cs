using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetTransportTypeRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        /// <summary>
        /// Unknown parameter. Always empty
        /// </summary>
        [JsonProperty("ok_id")]
        public string OkId { get; set; }
    }

    public class GetTransportTypeRequest : Request
    {
        private const string _method = "getTransTypeTree";
        [JsonProperty("params")]
        public GetTransportTypeRequestParams Params { get; set; }

        /// <summary>
        /// Get tree of all routes and all transport types (trolleybus, bus, tram)
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        public GetTransportTypeRequest(int requestId, string sessionId) : base(requestId, _method)
        {
            Params = new GetTransportTypeRequestParams
            {
                OkId = string.Empty,
                SessionId = sessionId
            };
        }
    }
}
