using LibraryManagementSystem.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace LybraryManagementSystem.Application.Attributes
{
    public class RoleValidatorAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private RoleType[] _roles;
        public RoleValidatorAttribute(params RoleType[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            for (int i = 0; i < _roles.Length; i++)
            {
                if ((int)_roles[i] < 1)
                {
                    context.Result =  
                }
                else if ((int)_roles[i] < 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
