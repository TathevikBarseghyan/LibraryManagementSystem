using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application;
using LybraryManagementSystem.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using LybraryManagementSystem.Application.Services;
using LybraryManagementSystem.Application.Interface;

using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        //private readonly UserManager<IdentityUser> _userManager;

        private readonly IUserService _userService;
        public IdentityController(UserManager<IdentityUser> userManager)
        {
            //_userManager = userManager;
        }

        //[HttpPost("register")]
        //public async Task<ActionResult> Register(UserModel userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new IdentityUser {UserName = userModel.Name, Email = userModel.Email };
        //    var result = await _userManager.CreateAsync(user, userModel.Password);

        //    //var user = new User()
        //    //{
        //    //    Id = userModel.Id,
        //    //    Name = userModel.Name,
        //    //    Password = userModel.Password
        //    //};

        //    return Ok(userModel);
        //}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = _userService.GetByUserName(userModel.UserName);
            if (exists != null) 
            {
                return Conflict("Username already exists");
            }

            var user = new UserModel()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                Password = UserService.GetHash(Encoding.UTF8.GetBytes(userModel.Password), Encoding.UTF8.GetBytes(UserService.GetSalt()))
            };

            _userService.Add(user);

            return Ok(userModel);
        }

        [HttpPost]
        public IActionResult LogIn(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existedModel = _userService.GetByUserName(userModel.UserName);

            string salt = existedModel.Salt;
            string hashedPass = existedModel.Hash;
            string checkingPass = UserService.GetHash(Encoding.UTF8.GetBytes(userModel.Password), Encoding.UTF8.GetBytes(salt));

            if (!hashedPass.Equals(checkingPass))
            {
                return Forbid("Invalid Password");
            }

            return Ok(userModel);
        }
    }
}
