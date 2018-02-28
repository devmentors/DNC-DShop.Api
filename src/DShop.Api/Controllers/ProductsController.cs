using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Products;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductsApi _productsApi;
        private readonly IBusPublisher _busPublisher;

        public ProductsController(IBusPublisher busPublisher)
        {
            _productsApi = RestClient.For<IProductsApi>("http://localhost:5001/"); // will be Docker internal DNS
            _busPublisher = busPublisher;
        }

        [HttpPut("")]
        public async Task CreateAsync([FromBody] CreateProduct command)
            => await _busPublisher.PublishCommandAsync(command);

        [HttpPost("")]
        public async Task UpdateAsync([FromBody] UpdateProduct command)
            => await _busPublisher.PublishCommandAsync(command);

        [HttpDelete("")]
        public async Task DeleteAsync([FromBody] DeleteProduct command)
            => await _busPublisher.PublishCommandAsync(command);
    }
}
