using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
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

        [HttpGet("get-all-Instances")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookInctanceService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("get-Instances")]
        public async Task<IActionResult> GetSameInstances(string title)
        {
            int id = await _bookService.GetIdByBookTitle(title); 
            var books = await _bookInctanceService.GetByBookIdAsync(id);

            return Ok(books);
        }

        [HttpDelete("delete-Instance")]        
        
        public async Task<IActionResult> Delete(int id)
        {
            await _bookInctanceService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("edit-Instance")]
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
