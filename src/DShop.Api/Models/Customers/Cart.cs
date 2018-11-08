using System;
using System.Collections.Generic;
using System.Linq;

namespace DShop.Api.Models.Customers
{
    public class Cart
    {
        public Guid Id { get; set; }
        public IList<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    }
}