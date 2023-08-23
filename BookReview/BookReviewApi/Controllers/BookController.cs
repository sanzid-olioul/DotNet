using BookReviewApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BookReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:Controller
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
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            return Ok(book);
        }
        [HttpGet("exist/{id}")]
        public async Task<IActionResult> IsbookExist(int id)
        {
            var res = await _bookRepository.IsBookExists(id);
            if(res == false)
            {
                return BadRequest(false);
            }
            return Ok(res);
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
        public async Task<IActionResult> UpdateBook(int id,Book book)
        {
            if (id == book.Id)
            {
                try
                {
                    var res = await _bookRepository.UpdateBook(book);
                    return Ok(res);
                }
                catch (Exception ex)
                {
                    return BadRequest(false);
                }
            }
            return BadRequest(false);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.GetBook(id);
            if (book == null)
            {
                return BadRequest(false);
            }
            var res = await _bookRepository.DeleteBook(book);
            if (res == true)
            {
                return Ok(book);
            }
            return BadRequest(false);
        }

    }
}
