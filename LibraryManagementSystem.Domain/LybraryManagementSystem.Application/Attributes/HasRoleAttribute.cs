
using Azure;
using Azure.Core;
using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Security.Claims;

namespace LybraryManagementSystem.Application.Attributes
{
    public class HasRoleAttribute : Attribute, IAsyncActionFilter
    {
        private readonly RoleType[] _roles;

        public HasRoleAttribute(params RoleType[] roles)
        {
            _roles = roles;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
            var userName = context.HttpContext.User.FindFirst("UserName").Value;
            var userRole = await userService.GetRoleByUserNameAsync(userName);
            // execute any code before the action executes

            if (_roles.Any(a => (int) a == userRole.RoleId))
            {
                await next();
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
        }
    }
}
