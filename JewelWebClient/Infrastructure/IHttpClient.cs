namespace JewelWebClient.Infrastructure
{
    public interface IHttpClient
    {
       Task<string> GetStringAsync(string uri, string authorizationtoken = null, 
           string authorizationmethod = "Bearer");
        Task<HttpResponseMessage> PostAsync<T>(string uri, T data,
            string authorizationToken = null, string authorizationMethod = "Bearer");
        Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
            string authorizationToken = null, string authorizationMethod = "Bearer");
        Task<HttpResponseMessage> DeleteAsync(string uri, 
            string authorizationToken=null, string authorizationMethod = "Bearer");
        
    }
}
