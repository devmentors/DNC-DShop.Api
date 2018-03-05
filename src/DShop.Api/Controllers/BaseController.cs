using System;
using System.Threading.Tasks;
using DShop.Common.RabbitMq;
using DShop.Common.Types;
using DShop.Messages.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly IBusPublisher _busPublisher;

        public BaseController(IBusPublisher busPublisher)
        {
            _busPublisher = busPublisher;
        }

        protected IActionResult GetAsync<T>(T model)
        {
            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected async Task<IActionResult> PostAsync<T>(T command) where T : ICommand 
            => await PublishAsync(command, ctx => Ok());

        protected async Task<IActionResult> PutAsync<T>(T command) where T : ICommand 
            => await PublishAsync(command, ctx => NoContent());

        protected async Task<IActionResult> DeleteAsync<T>(T command) where T : ICommand 
            => await PublishAsync(command, ctx => NoContent());

        private async Task<IActionResult> PublishAsync<T>(T command, 
            Func<CorrelationContext,IActionResult> response) where T : ICommand 
        {
            var context = new CorrelationContext();
            await _busPublisher.PublishCommandAsync(command, context);

            return response(context);
        }
    }
}