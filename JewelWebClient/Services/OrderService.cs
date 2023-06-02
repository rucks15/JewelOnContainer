using JewelWebClient.Infrastructure;
using JewelWebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JewelWebClient.Services
    {
    public class OrderService : IOrderService
        {
        
        private IHttpClient _apiClient;
        private readonly IConfiguration _configuration;
        private readonly string _remoteBaseUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public OrderService(IConfiguration configuration, IHttpClient httpClient,
            IHttpContextAccessor httpContextAccessor, ILoggerFactory logger)
            {
            _remoteBaseUrl = $"{configuration["OrderUrl"]}/api/orders";
            _apiClient = httpClient;
            _configuration = configuration;
                _httpContextAccessor = httpContextAccessor;
            _logger = logger.CreateLogger<OrderService>();
            }

        private async Task<string> GetUserTokenAsync()
            {
            var context = _httpContextAccessor.HttpContext;
            return await context.GetTokenAsync("access_token");
            }
        public async Task<int> CreateOrder(Order order)
            {
            var token = GetUserTokenAsync();

            var addNewOrderUri = APIPaths.Order.AddNewOrder(_remoteBaseUrl);
            _logger.LogDebug(" OrderUri " + addNewOrderUri);

            var response = await _apiClient.PostAsync(addNewOrderUri, order, token.Result);

            if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError) 
                {
                throw new Exception("Error creating order, try later.");
                }
            var jsonstring = response.Content.ReadAsStringAsync();
            jsonstring.Wait();
            dynamic data = JObject.Parse(jsonstring.Result);
            string value = data.OrderId;
            return Convert.ToInt32(value);
            }

        public async Task<Order> GetOrder(string orderId)
            {
            var token = GetUserTokenAsync();

            var getOrderUri = APIPaths.Order.GetOrder(_remoteBaseUrl, orderId);
            var datastring = await _apiClient.GetStringAsync(getOrderUri, token.Result);

            var response = JsonConvert.DeserializeObject<Order>(datastring);
            return response;
            }
        }
    }
