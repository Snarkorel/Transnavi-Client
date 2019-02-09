using System.Collections.Generic;
using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class GetUnitsResponse : Response
    {
        [JsonProperty("result")]
        public List<VehicleInfo> Result { get; set; }
    }
}
