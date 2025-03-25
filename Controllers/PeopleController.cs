using System;
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
        [HttpPut]
        public IActionResult Add([FromBody]Person person) {
            var existing = _personService.Get(person.Id);
            if (existing != null)
            {
                return Conflict();
            }
            _personService.Add(person);
            return Ok();

        }

        [HttpDelete("id")]
        public IActionResult Delete(string id) {
            var existing = _personService.Get(id);
            if (existing == null)
            {
                return Conflict();
            }
            _personService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll() {
            var people = _personService.Get();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id) {
            var person = _personService.Get(id);
            if (person is null) {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Person person) {

            if (id != person.Id)
            {
                return BadRequest();
            }

            var oldPerson = _personService.Get(id);
            if (person is null)
            {
                return NotFound();
            }
            _personService.Update(person);
            return Ok();
        }
    }
}
