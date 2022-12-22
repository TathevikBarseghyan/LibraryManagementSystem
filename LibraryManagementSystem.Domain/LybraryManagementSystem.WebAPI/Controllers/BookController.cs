using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Attributes;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Models.BookInstance;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IBookInstanceService _bookInstanceService;

        public BookController(IBookService bookService, IAuthorService authorService, IAuthorBookService authorBookService, IBookInstanceService bookInstanceService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _authorBookService = authorBookService;
            _bookInstanceService = bookInstanceService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] BookModel bookModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _bookService.AddAsync(bookModel);
            //await _bookService.SaveChangesAsync();
            
            return Ok(bookModel);
        }

        [Authorize]
        [RoleValidator(RoleType.Admin)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int bookId)
        {
            var books = await _bookService.GetByIdAsync(bookId);
            return Ok(books);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] BookEditModel bookEditModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            await _bookService.UpdateAsync(bookEditModel);

            return Ok(bookEditModel);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
    }
}
