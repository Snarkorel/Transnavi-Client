using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

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

        //TODO: reqeuest-response tasks, start session, etc.
    }
}
