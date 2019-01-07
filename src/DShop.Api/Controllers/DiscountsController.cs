using System;
using System.Threading.Tasks;
using DShop.Api.Messages.Commands.Discounts;
using DShop.Api.Services;
using DShop.Common.Mvc;
using DShop.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    [AllowAnonymous]
    public class DiscountsController : BaseController
    {
        private readonly IDiscountsService _discountsService;

        public DiscountsController(IBusPublisher busPublisher,
            IDiscountsService discountsService) : base(busPublisher)
        {
            _discountsService = discountsService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Get(Guid customerId)
            => await _discountsService.FindAsync(customerId);

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<object>> GetDetails(Guid id)
            => Result(await _discountsService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateDiscount command)
            => await SendAsync(command.BindId(c => c.Id), resourceId: command.Id,
                resource: "discounts");
    }
}