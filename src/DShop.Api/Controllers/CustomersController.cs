using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Customers;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomersStorage _storage;

        public CustomersController(IBusPublisher busPublisher,
            ICustomersStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet("")]
        public async Task<IActionResult> BrowseAsync([FromQuery] BrowseCustomers query)
            => GetAsync(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => GetAsync(await _storage.GetAsync(id));

        [HttpPost("")]
        public async Task<IActionResult> PostAsync([FromBody] CreateCustomer command)
            => await PublishAsync(command);
    }
}
