namespace ShopEZ.API.DTOs
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderItemResponseDTO> Items { get; set; }
    }

    public class OrderItemResponseDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}