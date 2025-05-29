using Batch27WebApi.Contract.Service;
using Batch27WebApi.DTO.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch27WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService) => _bookService = bookService;

        [HttpPost ]
        public IActionResult CreateBook([FromBody] BookRequestModel bookRequestModel)
        {
            if(ModelState.IsValid)
            {
              var result = _bookService.CreateBook(bookRequestModel);
                return Ok(result);
            }          
            else
            {
                Console.WriteLine("Error while creating a new book");
                return BadRequest();
            }            
        }

        [HttpPut ("{bookid}")]
        public IActionResult UpdateBook(string bookid, [FromBody] UpdateBookRequestModel bookRequestModel)
        {
            var book = _bookService.Update(bookid, bookRequestModel);
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            var book = _bookService.GetAll();
            return Ok(book);
        }

        [HttpDelete("{bookid}")]
        public IActionResult DeleteBook(string bookid)
        {
            var del = _bookService.Delete(bookid);
            return Ok(del);
        }
    }
}
