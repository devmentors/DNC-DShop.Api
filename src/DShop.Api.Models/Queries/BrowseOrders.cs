
using System;

namespace DShop.Api.Models.Queries
{
    public class BrowseOrders : PagedQuery
    {
        public Guid CustomerId { get; set; }
    }
}
