namespace JewelWebClient.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        public CustomHttpClient()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> GetStringAsync(string uri, string authorizationtoken = null, string authorizationmethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
