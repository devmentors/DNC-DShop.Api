using System;

namespace DShop.Api.Queries
{
    public class BrowseOrders : PagedQuery
    {
        public Guid CustomerId { get; set; }
    }
}
