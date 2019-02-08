using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetUnitArriveRequestParams
    {
        public string sid { get; set; }
        public string u_id { get; set; }
    }

    public class GetUnitArriveRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetUnitArriveRequestParams @params { get; set; }
        public int id { get; set; }

        //TODO: .ctor
    }
}
