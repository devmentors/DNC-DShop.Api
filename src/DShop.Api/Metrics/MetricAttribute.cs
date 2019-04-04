using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace DShop.Api.Metrics
{
    public class MetricAttribute : ActionFilterAttribute
    {
        public Metric Metric { get; }

        public MetricAttribute(Metric metric)
        {
            Metric = metric;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            using (var scope = context.HttpContext.RequestServices.CreateScope())
            {
                var registry = scope.ServiceProvider.GetService<ICustomMetricsRegistry>();
                switch (Metric)
                {
                    case Metric.GetProductsQuery:
                        registry.IncrementGetProductsQuery();
                        break;
                }
            }
        }
    }
}