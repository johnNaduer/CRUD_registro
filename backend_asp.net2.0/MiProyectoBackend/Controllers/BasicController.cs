using Microsoft.AspNetCore.Mvc;

namespace MiProyectoBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("¡Hola desde BasicController!");
        }
    }
}
