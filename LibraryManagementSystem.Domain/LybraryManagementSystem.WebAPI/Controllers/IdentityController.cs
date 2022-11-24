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

        //[Inject]
        //IUserService _userService { get; set; }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(AddModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = await _userService.GetByUserName(addModel.UserName);
            if (exists != null) 
            {
                return Conflict("Username already exists");
            }
            
            await _userService.AddAsync(addModel);
            await _userService.SaveChangesAsync();

            return Ok(addModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetByUserName(logInModel.UserName);
            if (user == null)
            {
                return Conflict();
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
