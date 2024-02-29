using Microsoft.AspNetCore.Mvc;

namespace MailGate.Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        [Route("/helloworld", Name = "HelloWorldAction")]
        public ActionResult<string> TestGet()
        {
            return Ok("Hello World!");
        }
    }
}
