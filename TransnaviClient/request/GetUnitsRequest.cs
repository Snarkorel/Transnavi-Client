using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.request
{
    public class GetUnitsRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("marshList")]
        public List<string> RoutesList { get; set; }
    }

    public class GetUnitsRequest : Request
    {
        private const string _method = "getUnits";

        [JsonProperty("params")]
        public GetUnitsRequestParams Params { get; set; }

        /// <summary>
        /// Get info about transport on route(s)
        /// </summary>
        /// <param name="requestId">Request ID</param>
        /// <param name="sessionId">Session ID</param>
        /// <param name="routeIds">List of route id's</param>
        public GetUnitsRequest(int requestId, string sessionId, List<int> routeIds) : base (requestId, _method)
        {
            Params = new GetUnitsRequestParams
            {
                SessionId = sessionId
            };
            var strList = new List<string>();
            foreach (var id in routeIds)
            {
                strList.Add(id.ToString());
            }
            Params.RoutesList = strList;
        }
    }
}
