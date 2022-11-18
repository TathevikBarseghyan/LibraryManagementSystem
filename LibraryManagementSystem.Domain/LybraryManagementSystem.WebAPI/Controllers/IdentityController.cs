using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application;
using LybraryManagementSystem.WebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net.Http;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Password = userModel.Password
            };

            return Ok(userModel);
        }

        [HttpPost]
        public IActionResult Add(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Password = userModel.Password
            };

            return Ok(userModel);
        }
    }
}
