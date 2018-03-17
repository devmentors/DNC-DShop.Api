using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Products;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;
using DShop.Common.Mvc;

namespace DShop.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsStorage _storage;

        public ProductsController(IBusPublisher busPublisher, IProductsStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseProducts query)
            => GetAsync(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id)
            => GetAsync(await _storage.GetAsync(id));

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProduct command)
            => await PublishAsync(command);

        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateAsync(Guid id, [FromBody] UpdateProduct command)
            => await PublishAsync(command.Bind(c => c.Id, id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
            => await PublishAsync(new DeleteProduct(id));
    }
}
