using Microsoft.AspNetCore.Mvc;
using MailGate.Server.Application.Dtos;
using MailGate.Server.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace MailGate.Server.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _taskService;

        public TasksController(ITasksService taskService)
        {
            _taskService = taskService;
        }

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
                var readEmailEntriesDto = _taskService.GetAllEmailEntries();
                return Ok(readEmailEntriesDto);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($">[TasksCtr] <GetAll> No entries were found - the table is empty!: {ex.Message}");
                return NotFound("There is no email entries in the database.");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($">[TasksCtr] <GetAll> Received null value - either list or DbSet{ex.Message}");
                return BadRequest($"The returned data seems to be invalid: {ex.Message}");
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
            {
                var emailEntryReadDto = _taskService.GetEmailEntry(emailEntryId);
                return Ok(emailEntryReadDto);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($">[TasksCtr] <GetById> negative email id \"{emailEntryId}\" - {ex.Message}");
                return BadRequest($"Email id \"{emailEntryId}\" is not a valid id.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($">[TasksCtr] <GetById> There is no email entry with this id: \"{emailEntryId}\" - {ex.Message}");
                return BadRequest($"There is no email entry with this id: \"{emailEntryId}\"");
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
                var createdEmailEntryReadDto = _taskService.CreateEmailEntry(createEmailEntryDto);
                return CreatedAtRoute(nameof(GetEmailEntryById), new { emailEntryId = createdEmailEntryReadDto.Id }, createdEmailEntryReadDto);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($">[TasksCtr] <Create> There was no email entry provided: {ex.Message}");
                return BadRequest($"There was an unexpected error while getting email entries : {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($">[TasksCtr] <Create> There was a problem with adding the new email entry: {ex.Message}");
                return BadRequest($"There was a problem with adding the new email entry: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">[TasksCtr] <Create> Unhandled exception : {ex.Message}");
                return BadRequest($"There was an unexpected error while getting email entries : {ex.Message}");
            }
        }
    }
}
