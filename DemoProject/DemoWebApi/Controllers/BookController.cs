using DemoWebApi.Data;
using DemoWebApi.Interface;
using Models;
using Microsoft.AspNetCore.Mvc;
namespace DemoWebApi.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        public class BookController : Controller
        {

            private readonly IBookRepository _bookRepository;
            public BookController(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            [HttpGet]
            public async Task<IActionResult> GetBooks()
            {
                var books = await _bookRepository.GetBooks();
                if (books == null)
                {
                    return NotFound();
                }
                return Ok(books);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBook(int id)
            {
                var book = await _bookRepository.GetBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            [HttpPost]
            public async Task<IActionResult> CreateBook(Book book)
            {
                try
                {
                    await _bookRepository.CreateBook(book);
                    return Ok("Created Successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }

            }
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateBook(int id, Book book)
            {
                if (id == book.Id)
                {
                    try
                    {
                        await _bookRepository.UpdateBook(book);
                        return Ok("Book Updated");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Something went wrong");
                    }

                }
                return BadRequest("Not valid");

            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBook(int id)
            {
                var book = await _bookRepository.GetBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                await _bookRepository.DeleteBook(book);
                return Ok("Deleted");

            }

        }
    
}
