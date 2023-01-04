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
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IAuthorBookService _authorBookService;
        private readonly IBookInstanceService _bookInstanceService;
        private readonly IUserService _userService;

        public BookController(IBookService bookService, IAuthorService authorService, IAuthorBookService authorBookService, IBookInstanceService bookInstanceService, IUserService userService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _authorBookService = authorBookService;
            _bookInstanceService = bookInstanceService;
            _userService = userService;
        }

        [Authorize]
        [HasRole(RoleType.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] BookModel bookModel)
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
        [HasRole(RoleType.Admin, RoleType.Client)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [Authorize]
        [HasRole(RoleType.Admin, RoleType.Client)]
        [HttpGet]
        public async Task<IActionResult> Get(int bookId)
        {
            var books = await _bookService.GetByIdAsync(bookId);
            return Ok(books);
        }

        [Authorize]
        [HasRole(RoleType.Admin)]
        [HttpPut("edit")]
        public async Task<IActionResult> EditaAsync([FromBody] BookEditModel bookEditModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }   

            await _bookService.UpdateAsync(bookEditModel);

            return Ok(bookEditModel);
        }

        [Authorize]
        [HasRole(RoleType.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }
    }
}
