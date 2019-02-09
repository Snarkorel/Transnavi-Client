using Newtonsoft.Json;

namespace transnavi.client.request
{
    public class GetUnitArriveRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("u_id")]
        public string TransportId { get; set; }
    }

    public class GetUnitArriveRequest : Request
    {
        private const string _method = "getUnitArrive";

        [JsonProperty("params")]
        public GetUnitArriveRequestParams Params { get; set; }
        
        /// <summary>
        /// Get arrival forecast for selected bus/trolleybus/tram
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="transportId">String that represents ID of bus, trolleybus or tram</param>
        public GetUnitArriveRequest(int requestId, string sessionId, string transportId) : base (requestId, _method)
        {           
            Params = new GetUnitArriveRequestParams()
            {
                SessionId = sessionId,
                TransportId = transportId
            };
        }
    }
}
