using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetRaceTreeResponseStopList
    {
        /// <summary>
        /// 0 for "all stops", "<num>" for certain stop
        /// </summary>
        [JsonProperty("rc_orderby")]
        public int StopOrder { get; set; }
        /// <summary>
        /// 0 for all stops, "<id>" for certain stop
        /// </summary>
        [JsonProperty("st_id")]
        public object StopId { get; set; } //TODO: return correct type instead of object
        [JsonProperty("st_title")]
        public string StopName { get; set; }
        /// <summary>
        /// Unknown parameter. Always empty
        /// </summary>
        [JsonProperty("rc_kkp")]
        public string rc_kkp { get; set; }
    }

    public class GetRaceTreeResponseResult
    {
        /// <summary>
        /// Route id including special direction (e.g. F)
        /// </summary>
        [JsonProperty("rl_id")]
        public string FullRouteId { get; set; }
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("rl_racetype")]
        public string RouteType { get; set; }
        [JsonProperty("rl_firststation_id")]
        public string FirstStopId { get; set; }
        [JsonProperty("rl_laststation_id")]
        public string LastStopId { get; set; }
        [JsonProperty("rl_firststation")]
        public string FirstStopName { get; set; }
        [JsonProperty("rl_laststation")]
        public string LastStopName { get; set; }
        [JsonProperty("stopList")]
        public List<GetRaceTreeResponseStopList> StopsList { get; set; }
    }

    public class GetRaceTreeResponse : Response
    {
        [JsonProperty("result")]
        public List<GetRaceTreeResponseResult> Result { get; set; }
    }
}
