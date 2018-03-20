using System;
using System.Threading.Tasks;
using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Orders;
using DShop.Services.Storage.Models.Queries;
using DShop.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using DShop.Api.Framework;

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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
        {
            if (!IsAdmin)
            {
                query.CustomerId = UserId;
            }

            return Collection(await _storage.BrowseAsync(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _storage.GetAsync(id), x => x.Customer.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrder command)
            => await PublishAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrder command)
            => await PublishAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await PublishAsync(new CancelOrder(id, UserId));
    }
}