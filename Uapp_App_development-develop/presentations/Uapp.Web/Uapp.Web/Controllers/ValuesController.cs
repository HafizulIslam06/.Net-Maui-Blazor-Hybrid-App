using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Uapp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
