using ShopEZ.API.Models;
using ShopEZ.API.DTOs;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(OrderDTO orderDto);
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
}