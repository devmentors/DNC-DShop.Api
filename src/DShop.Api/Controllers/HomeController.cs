using DShop.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace DShop.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher, ITracer tracer) : base(busPublisher, tracer)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("DShop API");
    }
}