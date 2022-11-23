using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LybraryManagementSystem.Application.Helper;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        private readonly IUserService _userService;
        public IdentityController(IConfiguration configuration, IUserService userService)
        {
            //_userManager = userManager;
            _configuration = configuration;
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
        public IActionResult Add(AddModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exists = _userService.GetByUserName(addModel.UserName);
            if (exists != null) 
            {
                return Conflict("Username already exists");
            }

            _userService.Add(addModel);

            return Ok(addModel);
        }

        private string GenerateToken(LogInModel logInModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim("UserName", logInModel.UserName)
            };

            var token = new JwtSecurityToken(
                 claims : claims,
                 expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: credentials); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("login")]
        public IActionResult LogIn(LogInModel logInModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.GetByUserName(logInModel.UserName);
            if (user == null)
            {
                return Conflict();
            }

            string salt = user.Salt;
            string hashedPass = user.Hash;
            string checkingPass = IdentityHelper.GetHash(logInModel.Password, Convert.FromBase64String(salt));

            if (!hashedPass.Equals(checkingPass))
            {
                return Forbid("Invalid Password");
            }

            if (hashedPass != checkingPass)
            {
                return Forbid("Invalid Password");
            }

            var token = GenerateToken(logInModel);

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
