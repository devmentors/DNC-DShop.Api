using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Customers;
using DShop.Api.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Common.Mvc;

namespace DShop.Api.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CartController(IBusPublisher busPublisher,
            ICustomersService customersService) : base(busPublisher)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Single(await _customersService.GetCartAsync(UserId));

        [HttpPost("items")]
        public async Task<IActionResult> Post([FromBody] AddProductToCart command)
            => await PublishAsync(command.Bind(c => c.CustomerId, UserId));

        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
            => await PublishAsync(new DeleteProductFromCart(UserId, productId));

        [HttpDelete("clear")]
        public async Task<IActionResult> Clear()
            => await PublishAsync(new ClearCart(UserId));
    }
}