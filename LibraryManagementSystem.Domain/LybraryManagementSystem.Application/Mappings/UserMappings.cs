using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public static class UserMappings
    {
        public static User MappToEntity(UserModel userModel)
        {
            return new User
            {
                Name = userModel.Name,
                Password = userModel.Password,
            };
        }
    }
}
