using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Enumerations;
using Microsoft.AspNetCore.Authorization;

namespace LybraryManagementSystem.Application.Attributes
{
    public class RoleValidator : ValidationAttribute
    {
        private Role[] _roles;
        public RoleValidator(params Role[] roles)
        {
            _roles = roles;
        }

        public override bool IsValid(object? value)
        {
            var role = (int)value;

            for (int i = 0; i < _roles.Length; i++)
            {
                if ((int)_roles[i] < 10)
                {
                    return true;
                }
                else if((int)_roles[i] < 20)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
