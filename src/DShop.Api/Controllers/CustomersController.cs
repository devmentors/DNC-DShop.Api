using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IBusPublisher _busPublisher;

        public CustomersController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }
    }
}
