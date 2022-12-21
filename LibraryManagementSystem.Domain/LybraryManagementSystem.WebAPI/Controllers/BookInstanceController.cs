using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Models.BookInstance;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    public class BookInstanceController : Controller
    {
        private readonly IBookInstanceService _bookInctanceService;
        private readonly IBookService _bookService;

        public BookInstanceController(IBookInstanceService bookInctanceService, IBookService bookService )
        {
            _bookInctanceService = bookInctanceService;
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] List<BookInstanceModel> bookInstanceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookInctanceService.AddRangeAsync(bookInstanceModel);
            //await _bookService.SaveChangesAsync();

            return Ok(bookInstanceModel);
        }
        [HttpGet("get-all-instances")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookInctanceService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("get-instances")]
        public async Task<IActionResult> GetInstances(string title)
        {
            var book = await _bookService.GetByBookTitle(title); 
            var books = await _bookInctanceService.GetByBookIdAsync(book.Id);

            return Ok(books);
        }

        [HttpDelete]        
        public async Task<IActionResult> Delete(int id)
        {
            await _bookInctanceService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("edit-instance")]
        public async Task<IActionResult> Edit([FromBody] BookInstanceModel bookInstanceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookInctanceService.UpdateAsync(bookInstanceModel);

            return Ok(bookInstanceModel);
        }
    }
}
