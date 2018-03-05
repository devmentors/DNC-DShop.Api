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

        public ProductsController(IBusPublisher busPublisher) : base(busPublisher)
        {
            _productsApi = RestClient.For<IProductsApi>("http://localhost:5001/"); // will be Docker internal DNS
        }

        [HttpPut("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProduct command)
            => await PostAsync(command);

        [HttpPost("")]
        public async Task<IActionResult>  UpdateAsync([FromBody] UpdateProduct command)
            => await PutAsync(command);

        [HttpDelete("")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteProduct command)
            => await DeleteAsync(command);
    }
}
