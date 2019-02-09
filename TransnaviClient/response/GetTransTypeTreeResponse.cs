using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace Snarkorel.transnavi.client.response
{
    public class TransportTypeTreeResponseRoute
    {
        public string mr_id { get; set; }
        public string mr_num { get; set; }
        public string mr_title { get; set; }
    }

    public class TransportTypeTreeResponseResult
    {
        public string tt_id { get; set; }
        public string tt_title { get; set; }
        public List<TransportTypeTreeResponseRoute> routes { get; set; }
    }

    public class TransportTypeTreeResponse : Response
    {
        public List<TransportTypeTreeResponseResult> result { get; set; }
    }
}
