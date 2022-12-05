using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models.Author;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public async  Task<IActionResult> Add(AuthorModel authorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (true)
            {

            }
        }


    }
}
