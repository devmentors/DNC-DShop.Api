using DShop.Common.Bus;
using DShop.Messages.Commands.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IPublishBus _publishBus;

        public ProductsController(IPublishBus publishBus)
        {
            _publishBus = publishBus;
        }

        [HttpPut("")]
        public async Task CreateAsync([FromBody] CreateProduct command)
            => await _publishBus.PublishCommandAsync(command, null);
    }
}
