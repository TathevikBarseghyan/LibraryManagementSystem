using LybraryManagementSystem.Application;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            //_userManager = userManager;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Add(AddModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userNameExists = await _userService.GetByUserNameOrEmail(addModel.UserName, addModel.Email);

            if (userNameExists != null) { return Conflict("User with UserName and email addres already exists"); }

            await _userService.AddAsync(addModel);
            await _userService.SaveChangesAsync();

            return Ok(addModel);
        }

        [AllowAnonymous]
        [HttpGet("Read")]
        public async Task<IActionResult> GetAllUsers()
        {
            var books = _userService.GetAll();

            return Ok(books);
        }
    }
}
