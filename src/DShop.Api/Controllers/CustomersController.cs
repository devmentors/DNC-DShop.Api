using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Api.Messages.Commands;
using DShop.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DShop.Common.Mvc;
using DShop.Api.Framework;
using DShop.Api.Messages.Commands.Customers;
using OpenTracing;

namespace DShop.Api.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomersService _customersService;

        public CustomersController(IBusPublisher busPublisher, ITracer tracer,
            ICustomersService customersService) : base(busPublisher, tracer)
        {
            _customersService = customersService;
        }

        [HttpGet]
        [AdminAuth]
        public async Task<IActionResult> Get([FromQuery] BrowseCustomers query)
            => Collection(await _customersService.BrowseAsync(query));

        [HttpGet("{id}")]
        [AdminAuth]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _customersService.GetAsync(id), x => x.Id == UserId || IsAdmin);

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomer command)
            => await SendAsync(command.Bind(c => c.Id, UserId), 
                resourceId: command.Id, resource: "customers");
    }
}
