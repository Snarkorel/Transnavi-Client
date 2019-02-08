using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace TransnaviClient.request
{
    public class GetUnitsRequestParams
    {
        public string sid { get; set; }
        public List<string> marshList { get; set; }
    }

    public class GetUnitsRequest
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public GetUnitsRequestParams @params { get; set; }
        public int id { get; set; }

        public GetUnitsRequest(string sid, List<int> routeIds)
        {
            id = 26;
            jsonrpc = "2.0";
            method = "getUnits";
            @params = new GetUnitsRequestParams();
            @params.sid = sid;
            var strList = new List<string>();
            foreach (var id in routeIds)
            {
                strList.Add(id.ToString());
            }
            @params.marshList = strList;
        }
    }
}
