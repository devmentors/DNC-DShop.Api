using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Products;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsStorage _storage;

        public ProductsController(IBusPublisher busPublisher, IProductsStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet("")]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseProducts query)
            => GetAsync(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => GetAsync(await _storage.GetAsync(id));

        [HttpPut("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProduct command)
            => await PublishAsync(command);

        [HttpPost("")]
        public async Task<IActionResult>  UpdateAsync([FromBody] UpdateProduct command)
            => await PublishAsync(command);

        [HttpDelete("")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteProduct command)
            => await DeleteAsync(command);
    }
}
