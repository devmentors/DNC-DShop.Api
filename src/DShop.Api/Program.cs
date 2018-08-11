using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DShop.Common.Metrics;
using DShop.Common.Mvc;
using System;

namespace DShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseLockbox()
                .UseAppMetrics();
    }
}
