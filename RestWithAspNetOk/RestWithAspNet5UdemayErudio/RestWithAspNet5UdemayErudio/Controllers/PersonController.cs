using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonBussines _personBussines;

        public PersonController(ILogger<PersonController> logger, IPersonBussines personBussines)
        {
            _logger = logger;
            _personBussines = personBussines;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personBussines.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBussines.FindByID(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }


        [HttpPost]
        public IActionResult Post([FromBody] PersonVo person)
        {

            if (person == null)
                return BadRequest();


            return Ok(_personBussines.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVo person)
        {

            if (person == null)
                return BadRequest();


            return Ok(_personBussines.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personBussines.FindByID(id);
            if (person == null)
                return NotFound();

            _personBussines.Delete(id);

            return NoContent();
        }



    }
}
