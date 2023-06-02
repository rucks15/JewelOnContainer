using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace JewelWebClient.Infrastructure
{
    public class CustomHttpClient : IHttpClient
        {
        private readonly HttpClient _httpClient;
        public CustomHttpClient()
            {
            _httpClient = new HttpClient();
            }
        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
            {

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            if (authorizationToken != null)
                {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
                }
            var response = await _httpClient.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();
            }

        public async Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken, string authorizationMethod)
            {

            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            if (authorizationToken != null)
                {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                    authorizationMethod, authorizationToken);
                }
            return await _httpClient.SendAsync(requestMessage);
            }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T data, string authorizationToken, string authorizationMethod)
            {
            return await DoPostPutAsync(HttpMethod.Post, uri, data, authorizationToken, authorizationMethod);
            }


        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken, string authorizationMethod)
            {
            return await DoPostPutAsync(HttpMethod.Post, uri, item, authorizationToken, authorizationMethod);
            }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T data, string authorizationToken, string authorizationMethod)
            {
            var requestMessage = new HttpRequestMessage(method, uri);

            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data),
                System.Text.Encoding.UTF8, "application/json");
            if (authorizationToken != null)
                {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                    authorizationToken, authorizationMethod);
                }
            var response = await _httpClient.SendAsync(requestMessage);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                throw new HttpRequestException();
                }
            return response;
            }
    }            
}
