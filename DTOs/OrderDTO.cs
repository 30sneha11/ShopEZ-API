using System.Collections.Generic;

namespace ShopEZ.API.DTOs
{
    public class OrderDTO
    {
        public int UserId { get; set; }

        public List<OrderItemDTO> Items { get; set; }
    }
}