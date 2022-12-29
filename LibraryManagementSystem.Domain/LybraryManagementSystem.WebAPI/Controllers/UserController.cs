using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.User;
using LybraryManagementSystem.Application.Attributes;

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

        

        [HttpPost("register")]
        public async Task<IActionResult> AddAsync([FromBody] AddUserModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userNameExists = await _userService.GetByUserName(addModel.UserName);

            if (userNameExists != null) { return Conflict("User with UserName and email addres already exists"); }

            await _userService.AddAsync(addModel);
            await _userService.SaveChangesAsync();

            return Ok(addModel);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("get")]
        public async Task<IActionResult> GetAsync(int userId)
        {
            var users = await _userService.GetByIdAsync(userId);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpGet("getByName")]
        public async Task<IActionResult> GetByNameAsync(string username)
        {
            var users = await _userService.GetByUserName(username);
            return Ok(users);
        }
        //[Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> EditAsync(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.UpdateAsync(userModel);

            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user != null)
            {
                await _userService.DeleteAsync(user.Id);
                await _userService.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}
