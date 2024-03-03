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
        [ProducesResponseType((200), Type = typeof(List<BookVo>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {

            return Ok(_bookBussines.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVo))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookBussines.FindByID(id);

            if (book == null)
                return NotFound();
            
            return Ok(book);
        }


        [HttpPost]
        [ProducesResponseType((200), Type = typeof(BookVo))]       
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVo book)
        {

            if (book == null)
                return BadRequest();


            return Ok(_bookBussines.Create(book));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(BookVo))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVo book)
        {

            if (book == null)
                return BadRequest();

            return Ok(_bookBussines.Update(book));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
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
