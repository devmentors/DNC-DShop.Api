using System;
using System.Threading.Tasks;
using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Api.Messages.Commands;
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
        public async Task<IActionResult> Post(CreateOrder command)
            => await SendAsync(command.BindId(c => c.Id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, CompleteOrder command)
            => await SendAsync(command.Bind(c => c.Id, id).Bind(c => c.CustomerId, UserId), 
                resourceId: command.Id, resource: "orders");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await SendAsync(new CancelOrder(id, UserId));
    }
}