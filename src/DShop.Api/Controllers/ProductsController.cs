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
using DShop.Api.Framework;

namespace DShop.Api.Controllers
{
    [AdminAuth]
    public class ProductsController : BaseController
    {
        private readonly IProductsStorage _storage;

        public ProductsController(IBusPublisher busPublisher, IProductsStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] BrowseProducts query)
            => Collection(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _storage.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProduct command)
            => await PublishAsync(command.BindId(c => c.Id), command.Id, "products");

        [HttpPut("{id}")]
        public async Task<IActionResult>  Put(Guid id, [FromBody] UpdateProduct command)
            => await PublishAsync(command.Bind(c => c.Id, id), command.Id, "products");

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => await PublishAsync(new DeleteProduct(id));
    }
}
