using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Snarkorel.transnavi.client.request;
using Newtonsoft.Json;
using Snarkorel.transnavi.client.response;
using System.Collections.Generic;

namespace Snarkorel.transnavi.client
{
    public class TransnaviClient
    {
        private string _sessionId;
        private int _requestId = 1;
        private bool _isInitialized;
        private HttpClient _client;
        private const string Uri = "http://moscow.map.office.transnavi.ru/api/rpc.php";
        private const string CredentialsFormat = "{0}:{1}";

        //TODO: enum for transportTypeId (1/2/3 - bus/trol/tram), enum for RouteDirection ("A"/"B"), enum for special trips(?, "F", "E", etc.)

        public TransnaviClient(string username, string password)
        {
            _client = new HttpClient();
            var credentials = string.Format(CredentialsFormat, username, password);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(credentials.ToCharArray())));
        }

        //TODO: error handling
        private Response GetResponse(Request request, Type responseType)
        {
            var requestJson = JsonConvert.SerializeObject(request);
            var httpResponse = PostHttpRequest(requestJson);
            _requestId++;
            var responseJson = JsonConvert.DeserializeObject(httpResponse.Result, responseType);
            return (Response)responseJson;
        }

        //TODO: auth error handling
        private async Task<string> PostHttpRequest(string payload)
        {
            var response = await _client.PostAsync(Uri, new StringContent(payload));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody.Length == 0)
                throw new Exception("Empty response!");
            return responseBody;
        }

        public bool GetInitialized()
        {
            return _isInitialized;
        }

        /// <summary>
        /// Initializes Transnavi client, obtains session ID
        /// </summary>
        /// <returns></returns>
        public bool Init()
        {
            var startReq = new StartSessionRequest(_requestId);
            try
            {
                var response = (StartSessionResponse)GetResponse(startReq, typeof(StartSessionResponse));
                _sessionId = response.Result.SessionId;
                _isInitialized = true;
            }
            catch (Exception)
            {
                _isInitialized = false;
                throw;
            }
            return _isInitialized;
        }
            
        /// <summary>
        /// Returns arrival forecast for stop with provided ID
        /// </summary>
        /// <param name="stopId"></param>
        /// <returns></returns>
        public List<GetStopArrivesResponseResult> GetStopArrivalForecast(int stopId)
        {
            var request = new GetStopArrivesRequest(_requestId, _sessionId, stopId);
            var response = (GetStopArrivesResponse)GetResponse(request, typeof(GetStopArrivesResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns list of all transport types and routes of which type
        /// </summary>
        /// <returns></returns>
        public List<GetTransportTypeTreeResponseResult> GetRoutesAndTransportTypes()
        {
            var request = new GetTransportTypeRequest(_requestId, _sessionId);
            var response = (GetTransportTypeTreeResponse)GetResponse(request, typeof(GetTransportTypeTreeResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns info about all stops in rectangle with provided geographical coordinates (latitude and longitude)
        /// </summary>
        /// <param name="minLatitude"></param>
        /// <param name="maxLatitude"></param>
        /// <param name="minLongitude"></param>
        /// <param name="maxLongitude"></param>
        /// <returns></returns>
        public List<GetStopsInRectResponseResult> GetAllStopsInRectangle(double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
        {
            var request = new GetStopsInRectRequest(_requestId, _sessionId, minLatitude, maxLatitude, minLongitude, maxLongitude);
            var response = (GetStopsInRectResponse)GetResponse(request, typeof(GetStopsInRectResponse));
            return response.Result;
        }

        /// <summary>
        /// Return info about route - stops, waypoints, park (depot)
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public GetRouteResponseResult GetRouteInfo(int routeId)
        {
            var request = new GetRouteRequest(_requestId, _sessionId, routeId);
            var response = (GetRouteResponse)GetResponse(request, typeof(GetRouteResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns info about vehicles on route - coordinates, speed, garage and state numbers, vehicle model
        /// </summary>
        /// <param name="routeId"></param>
        /// <returns></returns>
        public List<VehicleInfo> GetRouteVehiclesInfo(int routeId) //TODO: support list of routes id instead of one route
        {
            var routesList = new List<int>
            {
                routeId
            };
            var request = new GetUnitsRequest(_requestId, _sessionId, routesList);
            var response = (GetUnitsResponse)GetResponse(request, typeof(GetUnitsResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns arrival time forecast for vehicle with provided ID
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public List<GetUnitArriveResponseResult> GetVehicleArrivalForecast(string vehicleId)
        {
            var request = new GetUnitArriveRequest(_requestId, _sessionId, vehicleId);
            var response = (GetUnitArriveResponse)GetResponse(request, typeof(GetUnitArriveResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns info about all vehicles in rectangle with provided geographical coordinates (latitude and longitude)
        /// </summary>
        /// <param name="minLatitude"></param>
        /// <param name="maxLatitude"></param>
        /// <param name="minLongitude"></param>
        /// <param name="maxLongitude"></param>
        /// <returns></returns>
        public List<VehicleInfo> GetAllVehiclesInRectangle(double minLatitude, double maxLatitude, double minLongitude, double maxLongitude)
        {
            var request = new GetUnitsInRectRequest(_requestId, _sessionId, minLatitude, maxLatitude, minLongitude, maxLongitude);
            var response = (GetUnitsInRectResponse)GetResponse(request, typeof(GetUnitsInRectResponse));
            return response.Result;
        }

        /// <summary>
        /// Returns info about all stops and special trips for selected route
        /// </summary>
        /// <param name="routeId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public List<GetRaceTreeResponseResult> GetRouteTripsInfo(int routeId, DateTime date)
        {
            var request = new GetRaceTreeRequest(_requestId, _sessionId, routeId, date);
            var response = (GetRaceTreeResponse)GetResponse(request, typeof(GetRaceTreeResponse));
            return response.Result;
        }

        //TODO: enum instead of direction string

        /// <summary>
        /// Return schedule for selected stop
        /// </summary>
        /// <returns></returns>
        public GetScheduleResponseResult GetSchedule(int routeId, DateTime date, string direction, int stopId)
        {
            var request = new GetScheduleRequest(_requestId, _sessionId, routeId, date, direction, stopId);
            var response = (GetScheduleResponse)GetResponse(request, typeof(GetScheduleResponse));
            return response.Result;
        }

        /// <summary>
        /// Return schedule for all stops in selected direction
        /// </summary>
        /// <returns></returns>
        public GetScheduleResponseResult GetSchedule(int routeId, DateTime date, string direction)
        {
            var request = new GetScheduleRequest(_requestId, _sessionId, routeId, date, direction);
            var response = (GetScheduleResponse)GetResponse(request, typeof(GetScheduleResponse));
            return response.Result;
        }
    }
}
