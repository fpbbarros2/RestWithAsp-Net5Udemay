using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet5UdemayErudio.Bussines;
using RestWithAspNet5UdemayErudio.Models;

namespace RestWithAspNet5UdemayErudio.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {


        private readonly ILogger<BookController> _logger;
        private IBookBussines _bookBussines;

        public BookController(ILogger<BookController> logger, IBookBussines bookBussines)
        {
            _logger = logger;
            _bookBussines = bookBussines;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_bookBussines.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookBussines.FindByID(id);

            if (book == null)
                return NotFound();
            
            return Ok(book);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            if (book == null)
                return BadRequest();


            return Ok(_bookBussines.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {

            if (book == null)
                return BadRequest();

            return Ok(_bookBussines.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookBussines.FindByID(id);
            if (book == null)
                return NotFound();

            _bookBussines.Delete(id);

            return NoContent();
        }



    }
}
