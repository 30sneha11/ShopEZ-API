namespace ShopEZ.API.DTOs
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public List<OrderItemDTO>? Items { get; set; }
    }

    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}