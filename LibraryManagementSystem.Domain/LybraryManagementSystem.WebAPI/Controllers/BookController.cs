using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddBookModel bookModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _bookService.AddAsync(bookModel);
            await _bookService.SaveChangesAsync();
            //await _bookService.AuthorSaveChangesAsync();


            return Ok(bookModel);
        }


        [HttpGet("Get")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpPut("EditBook")]
        public async Task<IActionResult> Edit(BookModel bookModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            await _bookService.UpdateAsync(bookModel);

            return Ok(bookModel);
        }

        [HttpDelete("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = _bookService.GetByIdAsync(id);

            if(book != null)
            {
                await _bookService.DeleteAsync(book.Id);
                await _bookService.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
