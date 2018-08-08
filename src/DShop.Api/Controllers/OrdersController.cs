using System;
using System.Threading.Tasks;
using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Orders;
using DShop.Api.Models.Queries;
using DShop.Common.Mvc;
using Microsoft.AspNetCore.Mvc;
using DShop.Api.Framework;

namespace DShop.Api.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IBusPublisher busPublisher,
            IOrdersService ordersService) : base(busPublisher)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BrowseOrders query)
           => Collection(await _ordersService.BrowseAsync(query.Bind(q => q.CustomerId, UserId)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _ordersService.GetAsync(id), x => x.Customer.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrder command)
            => await PublishAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, [FromBody] CompleteOrder command)
            => await PublishAsync(command.Bind(c => c.Id, id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await PublishAsync(new CancelOrder(id, UserId));
    }
}