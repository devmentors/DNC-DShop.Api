using System;
using System.Collections.Generic;

namespace DShop.Api.Models.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public OrderStatus Status { get; set; }
        public int ItemsCount { get; set; }

        public enum OrderStatus : byte
        {
            Created = 0,
            Completed = 1,
            Canceled = 2,
        }
    }
}
