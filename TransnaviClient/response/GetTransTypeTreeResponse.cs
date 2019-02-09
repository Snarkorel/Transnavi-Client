using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetTransportTypeTreeResponseRoute
    {
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("mr_num")]
        public string RouteNumber { get; set; }
        [JsonProperty("mr_title")]
        public string RouteName { get; set; }
    }

    public class GetTransportTypeTreeResponseResult
    {
        [JsonProperty("tt_id")]
        public string TransportTypeId { get; set; }
        [JsonProperty("tt_title")]
        public string TransportTypeName { get; set; }
        [JsonProperty("routes")]
        public List<GetTransportTypeTreeResponseRoute> Routes { get; set; }
    }

    public class GetTransportTypeTreeResponse : Response
    {
        [JsonProperty("result")]
        public List<GetTransportTypeTreeResponseResult> Result { get; set; }
    }
}
