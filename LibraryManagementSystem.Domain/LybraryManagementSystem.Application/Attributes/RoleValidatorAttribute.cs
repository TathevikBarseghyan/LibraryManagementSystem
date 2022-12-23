
using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Security.Claims;

namespace LybraryManagementSystem.Application.Attributes
{
    public  class RoleValidatorAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private RoleType[] _roles;

        private readonly IUserService _userService;
        
        public RoleValidatorAttribute(params RoleType[] roles)
        {
            _roles = roles;
        }
        public RoleValidatorAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var userName = context.HttpContext.User.FindFirst("UserName").Value;
            
            var userRole = await _userService.GetRoleByUserNameAsync(userName);

            //if (_roles.Any(r => r.Equals(userRole.RoleId)))
            //{

            //}
        }
    }
}
