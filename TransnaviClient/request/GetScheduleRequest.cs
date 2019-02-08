using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetScheduleRequestParams
    {
        public string sid { get; set; }
        public string mr_id { get; set; }
        public string data { get; set; }
        public string rl_racetype { get; set; }
        public string rc_kkp { get; set; }
        public int st_id { get; set; }
    }

    public class GetScheduleRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetScheduleRequestParams @params { get; set; }
        public int id { get; set; }

        //TODO: support for A/B stops, support for intermediate stop, support for full schedule (rc_kkp, st_id)
        //TODO: .ctor
    }
}
