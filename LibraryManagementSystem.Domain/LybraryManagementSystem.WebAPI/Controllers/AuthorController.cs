﻿using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models.Author;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> Add(AuthorModel authorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorNameExists = await _authorService.GetByAuthorName(authorModel.FirstName, authorModel.LastName);

            if (authorNameExists != null) { return Conflict("Author addres already exists"); }

            await _authorService.AddAsync(authorModel);
            await _authorService.SaveChangesAsync();

            return Ok(authorModel);
        }

        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorService.GetByIdAsync(id);

            if (author != null)
            {
                await _authorService.DeleteAsync(author.Id);
                await _authorService.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}