using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetRouteResponseStopList
    {
        [JsonProperty("st_id")]
        public string StopId { get; set; }
        [JsonProperty("st_title")]
        public string StopName { get; set; }
        [JsonProperty("st_lat")]
        public string StopLatitude { get; set; }
        [JsonProperty("st_long")]
        public string StopLongitude { get; set; }
    }

    public class GetRouteResponseCoordList
    {
        [JsonProperty("rd_lat")]
        public string Latitude { get; set; }
        [JsonProperty("rd_long")]
        public string Longitude { get; set; }
    }

    public class GetRouteResponseRace
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
        [JsonProperty("stopList")]
        public List<GetRouteResponseStopList> StopsList { get; set; }
        [JsonProperty("coordList")]
        public List<GetRouteResponseCoordList> WaypointsCoordList { get; set; }
    }

    public class GetRouteResponsePark
    {
        [JsonProperty("rl_id")]
        public string ParkId { get; set; }
        [JsonProperty("rl_id")]
        public string ParkName { get; set; }
    }

    public class GetRouteResponseResult
    {
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("mr_num")]
        public string RouteName { get; set; }
        [JsonProperty("mr_title")]
        public string RouteTitle { get; set; }
        [JsonProperty("races")]
        public List<GetRouteResponseRace> Trips { get; set; }
        [JsonProperty("parks")]
        public List<GetRouteResponsePark> Parks { get; set; }
    }

    public class GetRouteResponse : Response
    {
        [JsonProperty("result")]
        public GetRouteResponseResult Result { get; set; }
    }
}
