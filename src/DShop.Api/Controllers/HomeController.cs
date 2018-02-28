using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet("")]
        public IActionResult Get() => Ok("DShop API");
    }
}