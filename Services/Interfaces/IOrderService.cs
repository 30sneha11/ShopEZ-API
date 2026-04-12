using ShopEZ.API.DTOs;
using ShopEZ.API.Models;

namespace ShopEZ.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDTO orderDto);

        Task<List<Order>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(int id);
    }
}