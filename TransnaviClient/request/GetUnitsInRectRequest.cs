using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetUnitsInRectRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("minlat")]
        public double MinLatitude { get; set; }
        [JsonProperty("maxlat")]
        public double MaxLatitude { get; set; }
        [JsonProperty("minlong")]
        public double MinLongtitude { get; set; }
        [JsonProperty("maxlong")]
        public double MaxLongtitude { get; set; }
    }

    public class GetUnitsInRectRequest : Request
    {
        private const string _method = "getUnitsInRect";

        [JsonProperty("params")]
        public GetUnitsInRectRequestParams Params { get; set; }

        /// <summary>
        /// Get info about all transport in rectangle with given coordinates
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="minLatitude"></param>
        /// <param name="minLongitude"></param>
        /// <param name="maxLatitude"></param>
        /// <param name="maxLongtitude"></param>
        public GetUnitsInRectRequest(int requestId, string sessionId, double minLatitude, double minLongitude, double maxLatitude, double maxLongtitude) : base(requestId, _method)
        {
            Params = new GetUnitsInRectRequestParams()
            {
                SessionId = sessionId,
                MinLatitude = minLatitude,
                MinLongtitude = minLongitude,
                MaxLatitude = maxLatitude,
                MaxLongtitude = maxLongtitude
            };
        }
    }
}
