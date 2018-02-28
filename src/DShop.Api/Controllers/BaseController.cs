using DShop.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Api.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected IActionResult OkOrNotFound<T>(T model)
        {
            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }
    }
}