using LibraryManagementSystem.Domain.Entities;

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

        //inverse mapper
        public static UserModel MapToModel(User user)
        {
            return new UserModel
            {
               Id= user.Id,
               Name = user.Name,
               Password= user.Password,
            };
        }

    }
}
