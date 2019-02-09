using System.Collections.Generic;
using Newtonsoft.Json; //TODO

namespace transnavi.client.response
{
    public class GetRouteResponseStopList
    {
        public string st_id { get; set; }
        public string st_title { get; set; }
        public string st_lat { get; set; }
        public string st_long { get; set; }
    }

    public class GetRouteResponseCoordList
    {
        public string rd_lat { get; set; }
        public string rd_long { get; set; }
    }

    public class GetRouteResponseRace
    {
        public string rl_id { get; set; }
        public string mr_id { get; set; }
        public string rl_racetype { get; set; }
        public string rl_firststation_id { get; set; }
        public string rl_laststation_id { get; set; }
        public string rl_firststation { get; set; }
        public string rl_laststation { get; set; }
        public List<GetRouteResponseStopList> stopList { get; set; }
        public List<GetRouteResponseCoordList> coordList { get; set; }
    }

    public class GetRouteResponsePark
    {
        public string pk_id { get; set; }
        public string pk_title { get; set; }
    }

    public class GetRouteResponseResult
    {
        public string mr_id { get; set; }
        public string mr_num { get; set; }
        public string mr_title { get; set; }
        public List<GetRouteResponseRace> races { get; set; }
        public List<GetRouteResponsePark> parks { get; set; }
    }

    public class GetRouteResponse : Response
    {
        public GetRouteResponseResult result { get; set; }
    }
}
