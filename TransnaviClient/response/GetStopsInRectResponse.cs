using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace TransnaviClient.response
{
    public class GetStopsInRectResponseResult
    {
        public string st_id { get; set; }
        public string st_title { get; set; }
        public string st_lat { get; set; }
        public string st_long { get; set; }
    }

    public class GetStopsInRectResponse : Response
    {
        public string jsonrpc { get; set; }
        public List<GetStopsInRectResponseResult> result { get; set; }
        public int id { get; set; }
    }
}
