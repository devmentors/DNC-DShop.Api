using App.Metrics;
using App.Metrics.Counter;

namespace DShop.Api.Metrics
{
    public class CustomMetricsRegistry : ICustomMetricsRegistry
    {
        private readonly IMetricsRoot _metricsRoot;
        private readonly CounterOptions _getProductsQuery = new CounterOptions {Name = "get-products-query"};

        public CustomMetricsRegistry(IMetricsRoot metricsRoot) => _metricsRoot = metricsRoot;
        
        public void IncrementGetProductsQuery() => _metricsRoot.Measure.Counter.Increment(_getProductsQuery);
    }
}