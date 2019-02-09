using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetStopArrivesResponseResult
    {
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("mr_num")]
        public string RouteNum { get; set; }
        [JsonProperty("rl_racetype")]
        public string RouteDirection { get; set; }
        [JsonProperty("tc_systime")]
        public string NavigationTime { get; set; }
        [JsonProperty("tc_arrivetime")]
        public string ArrivalTime { get; set; }
        [JsonProperty("firststation_title")]
        public string FirstStopName { get; set; }
        [JsonProperty("laststation_title")]
        public string LastStopName { get; set; }
        [JsonProperty("tt_id")]
        public string TransportTypeId { get; set; }
        /// <summary>
        /// Unknown parameter. Always 1.
        /// </summary>
        [JsonProperty("u_inv")]
        public string u_inv { get; set; }
    }

    public class GetStopArrivesResponse : Response
    {
        [JsonProperty("result")]
        public List<GetStopArrivesResponseResult> Result { get; set; }
    }
}
