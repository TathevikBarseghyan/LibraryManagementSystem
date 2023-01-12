using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LybraryManagementSystem.Application.Models.User;
using LybraryManagementSystem.Application.Services;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IPasswordResetService _passwordResetService;
        private readonly IIdentityService _identityService;

        public IdentityController(IUserService userService,
            INotificationService notificationServicel,
            IPasswordResetService passwordResetService,
            IIdentityService identityService)
        {
            //_userManager = userManager;
            _userService = userService;
            _notificationService = notificationServicel;
            _passwordResetService = passwordResetService;
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogInAsync(LogInModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operation = await _userService.LogInAsync(logInModel);

            if (!operation.Success)
            {
                return BadRequest(operation.Error);
            }

            return Ok(operation.Result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int userId)
        {
            return Ok();
        }

        [HttpPost("forgot-pass")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (_userService.GetByEmailAsync(email) == null)
            {
                return BadRequest("User dosen't seem to exist");
            }

            await _identityService.ForgotPasswordAsync(email);

            return Ok();
        }

        [HttpPost("reset-pass")]
        public async Task<IActionResult> RessetPassword(PasswordResetModel passwordResetModel, [FromQuery] string guid)
        {
            //var guid = HttpContext.Request.Query["guid"].ToString();
            //var userId = int.Parse(HttpContext.Request.Query["id"]);
            //var guid = "cd66964a-98b1-4840-a264-0c90c391be8b";
            //var userId = 1003;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //passwordResetModel.GuId = HttpContext.GetRouteValue();
            await _passwordResetService.ResetPasswordAsync(passwordResetModel, guid);
            return Ok();
        }
    }
}
