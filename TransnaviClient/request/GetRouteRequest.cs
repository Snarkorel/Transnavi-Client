using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetRouteRequestParams
    {
        public string sid { get; set; }
        public string mr_id { get; set; }
    }

    public class GetRouteRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetRouteRequestParams @params { get; set; }
        public int id { get; set; }

        public GetRouteRequest(string sid, int routeId)
        {
            id = 21;
            jsonrpc = "2.0";
            method = "getRoute";
            @params = new GetRouteRequestParams();
            @params.sid = sid;
            @params.mr_id = routeId.ToString();
        }
    }
}
