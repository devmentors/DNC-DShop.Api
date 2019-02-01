using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Api.Messages.Commands;
using DShop.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Api.Messages.Commands.Customers;
using DShop.Common.Mvc;
using OpenTracing;

namespace DShop.Api.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CartController(IBusPublisher busPublisher, ITracer tracer,
            ICustomersService customersService) : base(busPublisher, tracer)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Single(await _customersService.GetCartAsync(UserId));

        [HttpPost("items")]
        public async Task<IActionResult> Post(AddProductToCart command)
            => await SendAsync(command.Bind(c => c.CustomerId, UserId));

        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
            => await SendAsync(new DeleteProductFromCart(UserId, productId));

        [HttpDelete]
        public async Task<IActionResult> Clear()
            => await SendAsync(new ClearCart(UserId));
    }
}