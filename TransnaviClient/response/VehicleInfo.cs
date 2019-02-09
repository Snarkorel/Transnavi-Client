using Newtonsoft.Json;

namespace Snarkorel.transnavi.client.response
{
    public class VehicleInfo
    {
        [JsonProperty("u_id")]
        public string VehicleId { get; set; }
        [JsonProperty("tt_id")]
        public string TransportTypeId { get; set; }
        [JsonProperty("pk_id")]
        public string ParkId { get; set; }
        [JsonProperty("u_statenum")]
        public string StateNumber { get; set; }
        [JsonProperty("u_garagnum")]
        public string GarageNumber { get; set; }
        [JsonProperty("u_model")]
        public string VehicleModel { get; set; }
        [JsonProperty("u_timenav")]
        public string NavigationTime { get; set; }
        [JsonProperty("u_lat")]
        public string Latitude { get; set; }
        [JsonProperty("u_long")]
        public string Longtitude { get; set; }
        [JsonProperty("u_speed")]
        public string Speed { get; set; }
        [JsonProperty("u_course")]
        public string Direction { get; set; }
        [JsonProperty("u_inv")]
        public string u_inv { get; set; } //I don't know what is is. Always 1.
        [JsonProperty("mr_id")]
        public string RouteId { get; set; }
        [JsonProperty("mr_num")]
        public string RouteNumber { get; set; }
        [JsonProperty("rl_racetype")]
        public string RouteDirection { get; set; }
        [JsonProperty("pk_title")]
        public string ParkName { get; set; }
        [JsonProperty("rl_firststation_title")]
        public string FirstStopName { get; set; }
        [JsonProperty("rl_laststation_title")]
        public string LastStopName { get; set; }
    }
}
