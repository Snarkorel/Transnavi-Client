using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace TransnaviClient.response
{
    public class GetUnitArriveResponseResult
    {
        public string u_id { get; set; }
        public string mr_id { get; set; }
        public string rl_racetype { get; set; }
        public string st_id { get; set; }
        public string ta_systime { get; set; }
        public string ta_arrivetime { get; set; }
        public string st_title { get; set; }
    }

    public class GetUnitArriveResponse
    {
        public string jsonrpc { get; set; }
        public List<GetUnitArriveResponseResult> result { get; set; }
        public int id { get; set; }
    }
}
