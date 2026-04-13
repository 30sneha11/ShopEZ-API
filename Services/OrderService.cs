using ShopEZ.API.Data;
using ShopEZ.API.Models;
using ShopEZ.API.DTOs;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> CreateOrderAsync(OrderDTO orderDto)
    {
        if (orderDto.Items == null || !orderDto.Items.Any())
            throw new Exception("Cart is empty");

        decimal totalAmount = 0;
        var orderItems = new List<OrderItem>();

        foreach (var item in orderDto.Items)
        {
            var product = await _context.Products.FindAsync(item.ProductId);

            if (product == null)
                throw new Exception($"Product with ID {item.ProductId} not found");

            if (item.Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");

            var itemTotal = product.Price * item.Quantity;
            totalAmount += itemTotal;

            orderItems.Add(new OrderItem
            {
                ProductId = product.ProductId,
                Quantity = item.Quantity,
                Price = product.Price
            });
        }

        var order = new Order
        {
            UserId = orderDto.UserId,
            OrderDate = DateTime.Now,
            TotalAmount = totalAmount,
            OrderItems = orderItems ?? new List<OrderItem>()
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }
}