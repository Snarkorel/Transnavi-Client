using Newtonsoft.Json;
using System;

namespace Snarkorel.transnavi.client.request
{
    public class GetScheduleRequestParams
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("data")]
        public string Date { get; set; }
        [JsonProperty("rl_racetype")]
        public string Direction { get; set; }
        /// <summary>
        /// Unknown parameter. Maybe used for definition of last stop in each direction (incl. special routes). Can be "A", "B", "E"
        /// </summary>
        [JsonProperty("rc_kkp")]
        public string RcKkp { get; set; }
        [JsonProperty("st_id")]
        public int StopId { get; set; }
    }

    public class GetScheduleRequest : Request
    {
        private const string _method = "getRaspisanie";

        [JsonProperty("params")]
        public GetScheduleRequestParams Params { get; set; }

        //TODO: const strings for directions ("A"/"B")

        /// <summary>
        /// Get schedule (with all parameters)
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="routeId"></param>
        /// <param name="date"></param>
        /// <param name="direction"></param>
        /// <param name="rcKkp"></param>
        /// <param name="stopId"></param>
        public GetScheduleRequest(int requestId, string sessionId, int routeId, DateTime date, string direction, string rcKkp, int stopId) : base(requestId, _method)
        {
            Params = new GetScheduleRequestParams()
            {
                SessionId = sessionId,
                RouteId = routeId.ToString(),
                Date = date.ToString("yyyy-MM-dd"),
                Direction = direction,
                RcKkp = rcKkp,
                StopId = stopId
            };
        }

        /// <summary>
        /// Get schedule (without unknown rc_kkp parameter)
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="routeId"></param>
        /// <param name="date"></param>
        /// <param name="direction"></param>
        /// <param name="stopId"></param>
        public GetScheduleRequest(int requestId, string sessionId, int routeId, DateTime date, string direction, int stopId) : base(requestId, _method)
        {
            Params = new GetScheduleRequestParams()
            {
                SessionId = sessionId,
                RouteId = routeId.ToString(),
                Date = date.ToString("yyyy-MM-dd"),
                Direction = direction,
                RcKkp = string.Empty,
                StopId = stopId
            };
        }

        /// <summary>
        /// Get schedule for all stops in direction
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="sessionId"></param>
        /// <param name="routeId"></param>
        /// <param name="date"></param>
        /// <param name="direction"></param>
        public GetScheduleRequest(int requestId, string sessionId, int routeId, DateTime date, string direction) : base(requestId, _method)
        {
            Params = new GetScheduleRequestParams()
            {
                SessionId = sessionId,
                RouteId = routeId.ToString(),
                Date = date.ToString("yyyy-MM-dd"),
                Direction = direction,
                RcKkp = string.Empty,
                StopId = 0
            };
        }

    }
}
