using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace transnavi.client.response
{
    public class GetRaceTreeResponseStopList
    {
        public int rc_orderby { get; set; }
        public object st_id { get; set; }
        public string st_title { get; set; }
        public string rc_kkp { get; set; }
    }

    public class GetRaceTreeResponseResult
    {
        public string rl_id { get; set; }
        public string mr_id { get; set; }
        public string rl_racetype { get; set; }
        public string rl_firststation_id { get; set; }
        public string rl_laststation_id { get; set; }
        public string rl_firststation { get; set; }
        public string rl_laststation { get; set; }
        public List<GetRaceTreeResponseStopList> stopList { get; set; }
    }

    public class GetRaceTreeResponse : Response
    {
        public List<GetRaceTreeResponseResult> result { get; set; }
    }
}
