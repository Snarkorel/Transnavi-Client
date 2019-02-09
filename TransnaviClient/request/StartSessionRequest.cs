namespace transnavi.client.request
{
    public class StartSessionRequest : Request
    {
        private const string _method = "startSession";

        /// <summary>
        /// Start session and get session id
        /// </summary>
        /// <param name="requestId"></param>
        public StartSessionRequest(int requestId) : base(requestId, _method)
        {
        }
    }
}
