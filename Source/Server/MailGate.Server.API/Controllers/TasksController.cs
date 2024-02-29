using Microsoft.AspNetCore.Mvc;
using MailGate.Server.Application.Dtos;

namespace MailGate.Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        [Route("/helloworld", Name = "HelloWorldAction")]
        public ActionResult<string> TestGet()
        {
            return Ok("Hello World!");
        }

        [HttpGet]
        [Route("", Name = "GetAllEmailEntries")]
        public ActionResult<IEnumerable<ReadEmailEntryDto>> GetAllEmailEntries()
        {
            try
            {
                //TODO: Implmenet function in Application layer
                return Ok("Here will be all Email Entries in the database!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">[TasksCtr] <GetAll> Unhandled exception : {ex.Message}");
                return BadRequest($"There was an unexpected error while getting email entries : {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{emailEntryId}", Name = "GetEmailEntryById")]
        public ActionResult<ReadEmailEntryDto> GetEmailEntryById(int emailEntryId)
        {
            try
            {   //TODO: Implmenet function in Application layer
                return Ok("Here will be returned Email Entry from the database!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">[TasksCtr] <GetById> Unhandled exception : {ex.Message}");
                return BadRequest($"There was an unexpected error while getting email entries : {ex.Message}");
            }
        }

        [HttpPost]
        [Route("", Name = "CreateEmailEntry")]
        public ActionResult CreateEmailEntry(CreateEmailEntryDto createEmailEntryDto)
        {
            try
            {
                //TODO: Implmenet function in Application layer
                //TODO: Swap with CreatedAtRoute()
                return Ok("Here will be returned created Email Entry and route to it!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">[TasksCtr] <Create> Unhandled exception : {ex.Message}");
                return BadRequest($"There was an unexpected error while getting email entries : {ex.Message}");
            }
        }
    }
}
