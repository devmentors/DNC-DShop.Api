using System;

namespace DShop.Api.Models.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public int ItemsCount { get; set; }
    }
}
