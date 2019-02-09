using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetStopsInRectResponseResult
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

    public class GetStopsInRectResponse : Response
    {
        [JsonProperty("result")]
        public List<GetStopsInRectResponseResult> Result { get; set; }
    }
}
