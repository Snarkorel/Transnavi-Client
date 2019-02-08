using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetStopArrivesRequestParams
    {
        public string sid { get; set; }
        public string st_id { get; set; }
    }

    public class GetStopArrivesRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetStopArrivesRequestParams @params { get; set; }
        public int id { get; set; }

        public GetStopArrivesRequest(string sid, int stopId)
        {
            id = 4;
            jsonrpc = "2.0";
            method = "getStopArrive";
            @params = new GetStopArrivesRequestParams();
            @params.sid = sid;
            @params.st_id = stopId.ToString();
        }
    }
}
