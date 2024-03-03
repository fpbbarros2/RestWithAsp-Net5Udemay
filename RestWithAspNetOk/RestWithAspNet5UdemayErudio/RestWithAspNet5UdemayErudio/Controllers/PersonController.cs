using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Data.Vo;
using RestWithAspNet5UdemayErudio.Hypermedia.Filters;

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
        [ProducesResponseType((200), Type = typeof(List<PersonVo>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_personBussines.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVo))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
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
        [ProducesResponseType((200), Type = typeof(PersonVo))]       
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVo person)
        {

            if (person == null)
                return BadRequest();


            return Ok(_personBussines.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVo))]       
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]        
        public IActionResult Put([FromBody] PersonVo person)
        {

            if (person == null)
                return BadRequest();


            return Ok(_personBussines.Update(person));
        }

        [HttpDelete("{id}")]        
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]        
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
