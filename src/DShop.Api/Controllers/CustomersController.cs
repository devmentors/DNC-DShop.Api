using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Customers;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Common.Mvc;
using DShop.Api.Framework;

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

        [HttpGet]
        [AdminAuth]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _storage.BrowseAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _storage.GetAsync(id), x => x.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomer command)
            => await PublishAsync(command.Bind(c => c.Id, UserId), 
                resourceId: command.Id, resource: "customers");
    }
}
