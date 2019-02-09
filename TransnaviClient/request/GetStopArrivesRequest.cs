using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetStopArrivesRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("st_id")]
        public string StopId { get; set; }
    }

    public class GetStopArrivesRequest : Request
    {
        private const string _method = "getStopArrive";

        [JsonProperty("params")]
        public GetStopArrivesRequestParams Params { get; set; }

        /// <summary>
        /// Get arrival forecast for stop with given ID
        /// </summary>
        /// <param name="requestId"
        /// <param name="sid"></param>
        /// <param name="stopId"></param>
        public GetStopArrivesRequest(int requestId, string sessionId, int stopId) : base(requestId, _method)
        {
            Params = new GetStopArrivesRequestParams
            {
                SessionId = sessionId,
                StopId = stopId.ToString()
            };
        }
    }
}
