using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace transnavi.client.response
{
    public class GetStopArrivesResponseResult
    {
        public string mr_id { get; set; }
        public string mr_num { get; set; }
        public string rl_racetype { get; set; }
        public string tc_systime { get; set; }
        public string tc_arrivetime { get; set; }
        public string firststation_title { get; set; }
        public string laststation_title { get; set; }
        public string tt_id { get; set; }
        public string u_inv { get; set; }
    }

    public class GetStopArrivesResponse : Response
    {
        public List<GetStopArrivesResponseResult> result { get; set; }
    }
}
