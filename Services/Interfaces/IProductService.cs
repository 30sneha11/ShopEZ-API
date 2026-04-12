using ShopEZ.API.Models;
using ShopEZ.API.DTOs;

namespace ShopEZ.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(ProductDTO dto);
        Task<bool> UpdateAsync(int id, ProductDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}