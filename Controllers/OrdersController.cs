using Microsoft.AspNetCore.Mvc;
using ShopEZ.API.DTOs;
using ShopEZ.API.Services.Interfaces;

namespace ShopEZ.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/orders
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
                return BadRequest(ex.Message);
            }
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }
    }
}