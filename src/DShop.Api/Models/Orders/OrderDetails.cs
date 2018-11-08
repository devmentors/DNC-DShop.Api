using DShop.Api.Models.Customers;
using DShop.Api.Models.Products;
using System.Collections.Generic;

namespace DShop.Api.Models.Orders
{
    public class OrderDetails : Order
    {
        public OrderCustomer Customer { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
