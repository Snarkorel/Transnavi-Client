using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetRaceTreeRequestParams
    {
        public string sid { get; set; }
        public string mr_id { get; set; }
        public string data { get; set; }
    }

    public class GetRaceTreeRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetRaceTreeRequestParams @params { get; set; }
        public int id { get; set; }

        //TODO: .ctor
    }
}
