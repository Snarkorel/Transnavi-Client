using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetUnitArriveResponseResult
    {
        [JsonProperty("u_id")]
        public string VehicleId { get; set; }
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("rl_racetype")]
        public string RouteDirection { get; set; }
        [JsonProperty("st_id")]
        public string StopId { get; set; }
        [JsonProperty("ta_systime")]
        public string NavigationTime { get; set; }
        [JsonProperty("ta_arrivetime")]
        public string ArrivalTime { get; set; }
        [JsonProperty("st_title")]
        public string StopName { get; set; }
    }

    public class GetUnitArriveResponse : Response
    {
        [JsonProperty("result")]
        public List<GetUnitArriveResponseResult> Result { get; set; }
    }
}
