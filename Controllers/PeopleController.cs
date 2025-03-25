using Microsoft.AspNetCore.Mvc;

namespace otodikWebAPI.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController: ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Add([FromBody]Person person) {
            var existing = _personService.Get(person.Id);
            if (existing != null)
            {
                return Conflict();
            }
            _personService.Add(person);
            return Ok();

        }
    }
}
