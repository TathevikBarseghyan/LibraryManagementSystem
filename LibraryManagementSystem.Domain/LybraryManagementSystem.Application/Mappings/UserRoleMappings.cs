using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.AuthorBook;
using LybraryManagementSystem.Application.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class UserRoleMappings
    {
        public static UserRole MapToEntity(UserRoleModel userRoleModel)
        {
            return new UserRole
            {
                UserId = userRoleModel.UserId,
                RoleId = userRoleModel.RoleId,
            };
        }

        public static UserRoleModel MapToModel(UserRole userRole)
        {
            return new UserRoleModel
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId,
            };
        }

        public static List<UserRoleModel> MapToModelList(List<UserRole> userRoles)
        {
            return userRoles.Select(MapToModel).ToList();
        }

        public static List<UserRole> MapToEntityList(List<UserRoleModel> userRoleModels)
        {
            return userRoleModels.Select(MapToEntity).ToList();
        }
    }
}
