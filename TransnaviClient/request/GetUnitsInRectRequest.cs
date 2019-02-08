using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetUnitsInRectRequestParams
    {
        public string sid { get; set; }
        public double minlat { get; set; }
        public double maxlat { get; set; }
        public double minlong { get; set; }
        public double maxlong { get; set; }
    }

    public class GetUnitsInRectRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetUnitsInRectRequestParams @params { get; set; }
        public int id { get; set; }

        //TODO: .ctor
    }
}
