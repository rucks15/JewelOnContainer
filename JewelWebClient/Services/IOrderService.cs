using JewelWebClient.Models;

namespace JewelWebClient.Services
    {
    public interface IOrderService
        {
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
        }
    }
