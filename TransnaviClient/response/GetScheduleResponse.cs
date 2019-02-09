using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetScheduleResponseMinute
    {
        [JsonProperty("minute")]
        public string Minute { get; set; }
        [JsonProperty("rl_racetype")]
        public string RouteDirection { get; set; }
    }

    public class GetScheduleResponseHour
    {
        [JsonProperty("hour")]
        public int Hour { get; set; }
        [JsonProperty("minutes")]
        public List<GetScheduleResponseMinute> Minutes { get; set; }
    }

    public class GetScheduleResponseStopList
    {
        [JsonProperty("rc_orderby")]
        public string StopOrderNum { get; set; }
        [JsonProperty("st_id")]
        public string StopId { get; set; }
        [JsonProperty("st_title")]
        public string StopName { get; set; }
        /// <summary>
        /// Unknown parameter. Maybe used for A/B stop definition. Always empty for intermediate stops. (found values: A, B, E)
        /// </summary>
        [JsonProperty("rc_kkp")]
        public string rc_kkp { get; set; }
        [JsonProperty("hours")]
        public List<GetScheduleResponseHour> Hours { get; set; }
    }

    public class GetScheduleResponseRace
    {
        /// <summary>
        /// Route ID including direction (A/B, etc.)
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
    }

    public class GetScheduleResponseResult
    {
        /// <summary>
        /// Unknown parameter. Always 0
        /// </summary>
        [JsonProperty("srv_id")]
        public string srv_id { get; set; }
        /// <summary>
        /// Unknown parameter
        /// </summary>
        [JsonProperty("rv_id")]
        public string rv_id { get; set; }
        /// <summary>
        /// Unknown parameter
        /// </summary>
        [JsonProperty("rv_dow")]
        public string rv_dow { get; set; }
        [JsonProperty("rv_season")]
        public string Season { get; set; }
        [JsonProperty("rv_startdate")]
        public string ValidFromDate { get; set; }
        [JsonProperty("rv_enddate")]
        public object ValidToDate { get; set; } //TODO: return as DateTime, can be null
        [JsonProperty("rv_enddateexists")]
        public string IsValidToDateExists { get; set; }
        /// <summary>
        /// Unknown parameter. Save as rv_id
        /// </summary>
        [JsonProperty("rv_num")]
        public string rv_num { get; set; }
        [JsonProperty("stopList")]
        public List<GetScheduleResponseStopList> StopsList { get; set; }
        /// <summary>
        /// Can be null. Used for list of special directions
        /// </summary>
        [JsonProperty("races")]
        public List<GetScheduleResponseRace> Trips { get; set; }
    }

    public class GetScheduleResponse : Response
    {
        [JsonProperty("result")]
        public GetScheduleResponseResult Result { get; set; }
    }
}
