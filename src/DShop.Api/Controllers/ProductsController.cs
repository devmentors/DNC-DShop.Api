using DShop.Api.ServiceForwarders;
using DShop.Common.Bus;
using DShop.Messages.Commands.Products;
using DShop.Messages.ReadModels;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductsApi _productsApi;
        private readonly IPublishBus _publishBus;

        public ProductsController(IPublishBus publishBus)
        {
            _productsApi = RestClient.For<IProductsApi>("http://localhost:5001/"); // will be Docker internal DNS
            _publishBus = publishBus;
        }

        [HttpGet("{id}/Details")]
        public async Task<ProductDetailsReadModel> GetProductDetailsAsync(Guid id)
            => await _productsApi.GetProductDetailsAsync(id);

        [HttpGet("All")]
        public async Task<IEnumerable<ProductReadModel>> GetAllProductsAsync()
            => await _productsApi.GetAllProductsAsync();

        [HttpGet("Filtered")]
        public async Task<IEnumerable<ProductReadModel>> GetProductsByVendorAsync([FromQuery] string vendor)
            => await _productsApi.GetProductsByVendorAsync(vendor);

        [HttpPut]
        public async Task CreateAsync([FromBody] CreateProduct command)
            => await _publishBus.PublishCommandAsync(command, null);

        [HttpPost]
        public async Task UpdateAsync([FromBody] UpdateProduct command)
            => await _publishBus.PublishCommandAsync(command, null);

        [HttpDelete]
        public async Task DeleteAsync([FromBody] DeleteProduct command)
            => await _publishBus.PublishCommandAsync(command, null);
    }
}
