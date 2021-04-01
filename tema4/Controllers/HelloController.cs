using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace tema4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    { 
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
        [HttpPost]
        public IActionResult Post(JObject payload)
        {
            return Ok(payload);
        }
    }
}
