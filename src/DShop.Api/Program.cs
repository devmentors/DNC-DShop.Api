using DShop.Common.Builders;
using Microsoft.AspNetCore.Hosting;

namespace DShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            ServiceBuilder
                .Create<Startup>(args)
                .WithPort(5000)
                .WithAutofac(containerBuilder => { })
                .WithNoDatabase()
                .WithServiceBus("service-bus", subscribeBus => { })
                .Build();
    }
}
