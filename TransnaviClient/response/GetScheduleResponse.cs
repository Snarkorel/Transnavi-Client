using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace transnavi.client.response
{
    public class GetScheduleResponseMinute
    {
        public string minute { get; set; }
        public string rl_racetype { get; set; }
    }

    public class GetScheduleResponseHour
    {
        public int hour { get; set; }
        public List<GetScheduleResponseMinute> minutes { get; set; }
    }

    public class GetScheduleResponseStopList
    {
        public string rc_orderby { get; set; }
        public string st_id { get; set; }
        public string st_title { get; set; }
        public string rc_kkp { get; set; }
        public List<GetScheduleResponseHour> hours { get; set; }
    }

    public class GetScheduleResponseResult
    {
        public string srv_id { get; set; }
        public string rv_id { get; set; }
        public string rv_dow { get; set; }
        public string rv_season { get; set; }
        public string rv_startdate { get; set; }
        public object rv_enddate { get; set; }
        public string rv_enddateexists { get; set; }
        public string rv_num { get; set; }
        public List<GetScheduleResponseStopList> stopList { get; set; }
        public List<object> races { get; set; }
    }

    public class GetScheduleResponse : Response
    {
        public string jsonrpc { get; set; }
        public GetScheduleResponseResult result { get; set; }
        public int id { get; set; }
    }
}
