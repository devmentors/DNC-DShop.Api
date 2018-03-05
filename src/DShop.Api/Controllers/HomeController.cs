using DShop.Common.RabbitMq;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBusPublisher busPublisher) : base(busPublisher)
        {
        }

        [HttpGet("")]
        public IActionResult Get() => Ok("DShop API");
    }
}