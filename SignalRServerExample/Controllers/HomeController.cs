using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRServerExample.Business;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyBusiness _myBusiness;

        public HomeController(MyBusiness x)
        {
            _myBusiness = x;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Home(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
