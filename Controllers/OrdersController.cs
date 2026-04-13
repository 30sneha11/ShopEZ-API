using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.Services.Interfaces;
using ShopEZ.API.DTOs;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderDTO orderDto)
    {
        try
        {
            var order = await _orderService.CreateOrderAsync(orderDto);
            return Ok(order);
        }
        catch (Exception ex)
        {
          return StatusCode(500, ex.ToString()); // 🔥 SHOW FULL ERROR
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);

        if (order == null)
            return NotFound();

        return Ok(order);
    }
}