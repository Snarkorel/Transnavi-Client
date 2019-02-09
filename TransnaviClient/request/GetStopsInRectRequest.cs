using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetStopsInRectRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("minlat")]
        public double MinLatitude { get; set; }
        [JsonProperty("maxlat")]
        public double MaxLatitude { get; set; }
        [JsonProperty("minlong")]
        public double MinLongitude { get; set; }
        [JsonProperty("maxlong")]
        public double MaxLongitude { get; set; }
    }

    public class GetStopsInRectRequest : Request
    {
        private const string _method = "getStopsInRect";

        [JsonProperty("params")]
        public GetStopsInRectRequestParams Params { get; set; }

        /// <summary>
        /// Get list of all stops in region with given coordinates
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="minLatitude"></param>
        /// <param name="maxLatitude"></param>
        /// <param name="minLongitude"></param>
        /// <param name="maxLongitude"></param>
        public GetStopsInRectRequest(int requestId, string sessionId, double minLatitude, double maxLatitude, double minLongitude, double maxLongitude) : base(requestId, _method)
        {
            Params = new GetStopsInRectRequestParams()
            {
                SessionId = sessionId,
                MinLatitude = minLatitude,
                MaxLatitude = maxLatitude,
                MinLongitude = minLongitude,
                MaxLongitude = maxLongitude
            };
        }
    }
}
