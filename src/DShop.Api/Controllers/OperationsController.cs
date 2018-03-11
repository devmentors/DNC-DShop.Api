using DShop.Api.ServiceForwarders;
using DShop.Common.RabbitMq;
using DShop.Messages.Commands.Customers;
using DShop.Services.Storage.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DShop.Api.Controllers
{
    public class OperationsController : BaseController
    {
        private readonly IOperationsStorage _storage;

        public OperationsController(IBusPublisher busPublisher,
            IOperationsStorage storage) : base(busPublisher)
        {
            _storage = storage;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
            => GetAsync(await _storage.GetAsync(id));
    }
}
