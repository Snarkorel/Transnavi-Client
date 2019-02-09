using Newtonsoft.Json;
using System;

namespace transnavi.client.request
{
    public class GetRaceTreeRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("data")]
        public string Date { get; set; }
    }

    public class GetRaceTreeRequest : Request
    {
        private const string _method = "getRaceTree";

        [JsonProperty("params")]
        public GetRaceTreeRequestParams Params { get; set; }

        /// <summary>
        /// Get all trips (A, B, special routes) for selected route
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="routeId"></param>
        /// <param name="date"></param>
        public GetRaceTreeRequest(int requestId, string sessionId, int routeId, DateTime date) : base(requestId, _method)
        {
            Params = new GetRaceTreeRequestParams()
            {
                SessionId = sessionId,
                RouteId = routeId.ToString(),
                Date = date.ToString("yyyy-MM-dd")
            };
        }
    }
}
