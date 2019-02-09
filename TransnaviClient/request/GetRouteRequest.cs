using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetRouteRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
    }

    public class GetRouteRequest : Request
    {
        private const string _method = "getRoute";

        [JsonProperty("params")]
        public GetRouteRequestParams Params { get; set; }

        /// <summary>
        /// Get all stops for selected route
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="routeId"></param>
        public GetRouteRequest(int requestId, string sessionId, int routeId) : base(requestId, _method)
        {
            Params = new GetRouteRequestParams
            {
                SessionId = sessionId,
                RouteId = routeId.ToString()
            };
        }
    }
}
