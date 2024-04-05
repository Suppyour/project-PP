using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Test2Controller : ControllerBase
    {
        [HttpGet("")]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
