using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.User;

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
        public async Task<IActionResult> Add(AddUserModel addModel)
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

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        //[Authorize]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(UserModel userModel)
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
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
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
