using Newtonsoft.Json;
using System.Collections.Generic;

namespace Snarkorel.transnavi.client.response
{
    public class GetUnitsInRectResponse : Response
    {
        [JsonProperty("result")]
        public List<VehicleInfo> Result { get; set; }
    }
}
