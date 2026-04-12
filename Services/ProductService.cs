using ShopEZ.API.Models;
using ShopEZ.API.DTOs;
using ShopEZ.API.Repositories.Interfaces;
using ShopEZ.API.Services.Interfaces;

namespace ShopEZ.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl,
                Stock = dto.Stock
            };

            await _repo.AddAsync(product);
            return product;
        }

        public async Task<bool> UpdateAsync(int id, ProductDTO dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.ImageUrl = dto.ImageUrl;
            product.Stock = dto.Stock;

            await _repo.UpdateAsync(product);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            await _repo.DeleteAsync(product);
            return true;
        }
    }
}