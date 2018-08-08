namespace DShop.Api.Models.Queries
{
    public class BrowseProducts : PagedQuery
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public BrowseProducts()
        {
            PriceTo = decimal.MaxValue;
        }
    }
}