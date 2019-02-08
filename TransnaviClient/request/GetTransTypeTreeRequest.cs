using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class TransportTypeRequestParams
    {
        public string sid { get; set; }
        public string ok_id { get; set; }
    }

    public class TransportTypeRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public TransportTypeRequestParams @params { get; set; }
        public int id { get; set; }

        public TransportTypeRequest(string sid)
        {
            id = 2;
            jsonrpc = "2.0";
            method = "getTransTypeTree";
            @params = new TransportTypeRequestParams();
            @params.ok_id = string.Empty;
            @params.sid = sid;
        }
    }
}
