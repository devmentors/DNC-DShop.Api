namespace DShop.Api.Metrics
{
    public interface ICustomMetricsRegistry
    {
        void IncrementGetProductsQuery();
    }
}