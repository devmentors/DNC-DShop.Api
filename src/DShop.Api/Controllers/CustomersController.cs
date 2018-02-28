using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ICustomersStorage _storage;

        public CustomersController(IBusPublisher busPublisher,
            ICustomersStorage storage)
        {
            _busPublisher = busPublisher;
            _storage = storage;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => OkOrNotFound(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => OkOrNotFound(await _storage.GetAsync(id));
    }
}
