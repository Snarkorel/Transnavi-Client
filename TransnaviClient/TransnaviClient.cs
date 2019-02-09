using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using transnavi.client.request;
using Newtonsoft.Json;
using transnavi.client.response;
using System.Collections.Generic;

namespace transnavi.client
{
    public class TransnaviClient
    {
        private string _sid;
        private int _requestId = 1;
        private bool _isInitialized;
        private static HttpClient _client;
        private const string Uri = "http://moscow.map.office.transnavi.ru/api/rpc.php";
        private const string CredentialsFormat = "{0}:{1}";

        public TransnaviClient(string username, string password)
        {
            var _client = new HttpClient();
            var credentials = string.Format(CredentialsFormat, username, password);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(credentials.ToCharArray())));
        }

        //TODO: error handling
        private Response GetResponse(Request request)
        {
            var requestJson = JsonConvert.SerializeObject(request);
            var httpResponse = PostHttpRequest(requestJson);
            _requestId++;
            var responseJson = JsonConvert.DeserializeObject<Response>(httpResponse.Result);
            return responseJson;
        }

        private static async Task<string> PostHttpRequest(string payload)
        {
            var response = await _client.PostAsync(Uri, new StringContent(payload));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody.Length == 0)
                throw new Exception("Empty response!");
            return responseBody;
        }

        public bool Init()
        {
            var startReq = new StartSessionRequest(_requestId);
            try
            {
                var response = GetResponse(startReq) as StartSessionResponse;
                _sid = response.Result.Sid;
                _isInitialized = true;
            }
            catch (Exception e)
            {
                _isInitialized = false;
                Console.WriteLine("Failed to initialize, exception: " + e.Message);
            }
            return _isInitialized;
        }

        public List<GetStopArrivesResponseResult> GetStopArrivalForecast(int stopId)
        {
            var stopArrReq = new GetStopArrivesRequest(_requestId, _sid, stopId);
            var response = GetResponse(stopArrReq) as GetStopArrivesResponse;
            return response.result;
        }

        //TODO: response error handling, auth error handling

        //TODO: reqeuest-response tasks, start session, etc.
    }
}
