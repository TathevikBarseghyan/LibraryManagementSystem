using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        //private readonly UserManager<IdentityUser> _userManager;

        private readonly IUserService _userService;
        public IdentityController(IUserService userService)
        {
            //_userManager = userManager;
            _userService = userService;
        }

        

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetByUserNameOrEmail(logInModel.UserName, null);
            if (user == null)
            {
                return Conflict("The account wasn't found");
            }

            if (!_userService.ValidateUser(user, logInModel))
            {
                return Forbid("Invalid password");
            }

            var token = _userService.GenerateToken(logInModel);

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int userId)
        {
            return Ok();
        }
    }
}
