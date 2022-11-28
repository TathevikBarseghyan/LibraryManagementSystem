﻿using LybraryManagementSystem.Application.Interface;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LogInModel logInModel)
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

            // TO DO
            //if (Invalid passs)
            //{
            //    return Forbid("Invalid password");
            //}

            //var token = _userService.GenerateToken(logInModel);

            return Ok(operation.Result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int userId)
        {
            return Ok();
        }
    }
}
