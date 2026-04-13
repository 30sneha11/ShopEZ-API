public async Task<OrderResponseDTO> CreateOrderAsync(OrderDTO orderDto)
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
        OrderItems = orderItems
    };

    _context.Orders.Add(order);
    await _context.SaveChangesAsync();

    // ✅ FIXED RETURN (NO CIRCULAR ERROR)
    return new OrderResponseDTO
    {
        OrderId = order.OrderId,
        UserId = order.UserId,
        TotalAmount = order.TotalAmount,
        Items = orderItems.Select(i => new OrderItemResponseDTO
        {
            ProductId = i.ProductId,
            Quantity = i.Quantity,
            Price = i.Price
        }).ToList()
    };
}