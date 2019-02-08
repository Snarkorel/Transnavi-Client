using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using TransnaviClient.request;
using Newtonsoft.Json;
using TransnaviClient.response;
using System.Collections.Generic;

namespace TransnaviClient
{
    public class TransnaviClient
    {
        private string _sid;
        private static HttpClient _client;
        private const string Uri = "http://moscow.map.office.transnavi.ru/api/rpc.php";
        private const string CredentialsFormat = "{0}:{1}";

        public TransnaviClient(string username, string password)
        {
            var _client = new HttpClient();
            var credentials = string.Format(CredentialsFormat, username, password);
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.Default.GetBytes(credentials.ToCharArray())));
        }

        private static async Task<string> PostHttpRequest(string payload)
        {
            try
            {
                var response = await _client.PostAsync(Uri, new StringContent(payload));
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody.Length == 0)
                    throw new Exception("Empty response");
                return responseBody;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to get response, exception: " + e.Message);
                return string.Empty;
            }
        }

        public void Init() //TODO: bool, error handling
        {
            var startReq = new StartSessionRequest();
            var startReqJson = JsonConvert.SerializeObject(startReq);
            var httpResponse = PostHttpRequest(startReqJson);
            var jsonResponse = JsonConvert.DeserializeObject<StartSessionResponse>(httpResponse.Result);
            _sid = jsonResponse.Result.Sid;
        }

        public List<GetStopArrivesResponseResult> GetStopArrivalForecast(int stopId)
        {
            var stopArrReq = new GetStopArrivesRequest(_sid, stopId);
            var stopArrJson = JsonConvert.SerializeObject(stopArrReq);
            var stopArrivesResponse = PostHttpRequest(stopArrJson);
            var stopArrRespJson = JsonConvert.DeserializeObject<GetStopArriveResponse>(stopArrivesResponse.Result);
            return stopArrRespJson.result;
        }

        

        //TODO: reqeuest-response tasks, start session, etc.
    }
}
