using ShopEZ.API.DTOs;

namespace ShopEZ.API.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> CreateOrderAsync(OrderDTO orderDto);

        Task<List<OrderResponseDTO>> GetAllOrdersAsync();

        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
    }
}