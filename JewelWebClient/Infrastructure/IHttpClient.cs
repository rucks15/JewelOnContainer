namespace JewelWebClient.Infrastructure
{
    public interface IHttpClient
    {
       Task<string> GetStringAsync(string uri, string authorizationtoken = null, string authorizationmethod = "Bearer");
    }
}
