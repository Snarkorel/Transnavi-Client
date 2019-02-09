using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class StartSessionResponseResult
    {
        [JsonProperty("sid")]
        public string SessionId { get; set; }
    }

    public class StartSessionResponse : Response
    {
        [JsonProperty("result")]
        public StartSessionResponseResult Result { get; set; }
    }
}
