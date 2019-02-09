﻿using System;
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
        private string _sid;
        private int _requestId = 1;
        private bool _isInitialized;
        private HttpClient _client;
        private const string Uri = "http://moscow.map.office.transnavi.ru/api/rpc.php";
        private const string CredentialsFormat = "{0}:{1}";

        //TODO: enum for transportTypeId (1/2/3 - bus/trol/tram), enum for RouteDirection ("A"/"B")

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

        public bool Init()
        {
            var startReq = new StartSessionRequest(_requestId);
            try
            {
                var response = (StartSessionResponse)GetResponse(startReq, typeof(StartSessionResponse));
                _sid = response.Result.SessionId;
                _isInitialized = true;
            }
            catch (Exception)
            {
                _isInitialized = false;
                throw;
            }
            return _isInitialized;
        }
            
        public List<GetStopArrivesResponseResult> GetStopArrivalForecast(int stopId)
        {
            var stopArrReq = new GetStopArrivesRequest(_requestId, _sid, stopId);
            var response = (GetStopArrivesResponse)GetResponse(stopArrReq, typeof(GetStopArrivesResponse));
            return response.Result;
        }

        //TODO: support all requests
    }
}
