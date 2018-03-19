using System;
using System.Linq;
using System.Threading.Tasks;
using DShop.Api.Framework;
using DShop.Common.RabbitMq;
using DShop.Common.Types;
using DShop.Messages.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    [Route("[controller]")]
    [Auth]
    public abstract class BaseController : Controller
    {
        private static readonly string AcceptLanguageHeader = "accept-language";
        private static readonly string OperationHeader = "x-operation";
        private static readonly string ResourceHeader = "x-resource";
        private static readonly string DefaultCulture = "en-us";
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

        protected IActionResult GetCollectionAsync<T>(T model)
        {
            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }

        protected async Task<IActionResult> PublishAsync<T>(T command, 
            string resource = "") where T : ICommand 
        {
            var context = GetContext<T>(resource);
            await _busPublisher.PublishCommandAsync(command, context);

            return Accepted(context);
        }

        protected IActionResult Accepted(ICorrelationContext context)
        {
            Response.Headers.Add(OperationHeader, $"operations/{context.Id}");
            if(!string.IsNullOrWhiteSpace(context.Resource))
            {
                Response.Headers.Add(ResourceHeader, context.Resource);
            }

            return base.Accepted();
        }

        protected ICorrelationContext GetContext<T>(string resource = "") where T : ICommand
        {
            var resourceId = Guid.NewGuid();
            if (!string.IsNullOrWhiteSpace(resource))
            {
                resource = $"{resource}/{resourceId}";
            }

            return CorrelationContext.Create<T>(Guid.NewGuid(), UserId, 
                resourceId, Request.Path.ToString(), Culture, resource);
        }

        protected Guid UserId
            => string.IsNullOrWhiteSpace(User?.Identity?.Name) ? 
                Guid.Empty : 
                Guid.Parse(User.Identity.Name);

        protected string Culture 
            => Request.Headers.ContainsKey(AcceptLanguageHeader) ? 
                    Request.Headers[AcceptLanguageHeader].First().ToLowerInvariant() :
                    DefaultCulture;
    }
}