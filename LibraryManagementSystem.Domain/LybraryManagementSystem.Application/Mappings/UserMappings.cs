using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;

namespace LybraryManagementSystem.Application.Mappings
{
    public static class UserMappings
    {
        public static User MapToEntity(UserModel userModel)
        {
            return new User
            {
                Name = userModel.Name,
                Password = userModel.Password,
            };
        }
        public static User LogInMapToEntity(LogInModel logInModel)
        {
            return new User
            {
                Name = logInModel.UserName,
                Password = logInModel.Password,
            };
        }
        //inverse mapper
        public static UserModel MapToModel(User user)
        {
            if (user == null)
            {

            }
            return new UserModel
            {
                Name = user.Name,
                Password = user.Password,
            };
        }
        
        
        public static LogInModel LogInMapToModel(User user)
        {
            return new LogInModel
            {
                UserName = user.Name,
                Password = user.Password,
            };
        }
    }
}
