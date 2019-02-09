using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace Snarkorel.transnavi.client.response
{
    public class GetUnitsResponseResult
    {
        public string u_id { get; set; }
        public string tt_id { get; set; }
        public string pk_id { get; set; }
        public string u_statenum { get; set; }
        public string u_garagnum { get; set; }
        public string u_model { get; set; }
        public string u_timenav { get; set; }
        public string u_lat { get; set; }
        public string u_long { get; set; }
        public string u_speed { get; set; }
        public string u_course { get; set; }
        public string u_inv { get; set; }
        public string mr_id { get; set; }
        public string mr_num { get; set; }
        public string rl_racetype { get; set; }
        public string pk_title { get; set; }
        public string rl_firststation_title { get; set; }
        public string rl_laststation_title { get; set; }
    }

    public class GetUnitsResponse : Response
    {
        public List<GetUnitsResponseResult> result { get; set; }
    }
}
