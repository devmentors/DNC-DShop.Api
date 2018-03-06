using System;
using System.Threading.Tasks;
using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Orders;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersStorage _storage;

        public OrdersController(IBusPublisher busPublisher,
            IOrdersStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
            => GetAsync(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => GetAsync(await _storage.GetAsync(id));

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateOrder command)
            => await PublishAsync(command);
    }
}
