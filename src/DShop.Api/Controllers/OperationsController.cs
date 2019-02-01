using DShop.Api.Services;
using DShop.Common.RabbitMq;
using DShop.Api.Messages.Commands;
using DShop.Api.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using OpenTracing;

namespace DShop.Api.Controllers
{
    [AllowAnonymous]
    public class OperationsController : BaseController
    {
        private readonly IOperationsService _operationsService;

        public OperationsController(IBusPublisher busPublisher,  ITracer tracer,
            IOperationsService operationsService) : base(busPublisher, tracer)
        {
            _operationsService = operationsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Single(await _operationsService.GetAsync(id));
    }
}
