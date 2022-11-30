using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Models.User;
using LybraryManagementSystem.Application.Services;
using System.Text;

namespace LybraryManagementSystem.Application.Mappings
{
    public static class UserMappings
    {
        public static User MapToEntity(UserModel userModel)
        {
            return new User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.UserName

            };
        }

        public static User MapToEntity(AddUserModel addModel)
        {
            if(addModel is null)
            {
                return null;
            }

            var salt = IdentityHelper.GetSalt();
            var hash = IdentityHelper.GetHash(addModel.Password, salt);

            return new User
            {
                UserName = addModel.UserName,
                Email = addModel.Email,
                Hash = hash,
                Salt = Convert.ToBase64String(salt),
                FirstName = addModel.FirstName,
                LastName = addModel.LastName,
            };
        }

        //inverse mapper
        public static UserModel MapToModel(User user)
        {
            var config = new MapperConfiguration(c =>
                c.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var mappedUser = mapper.Map<UserModel>(user);

            return mappedUser;
        }

        public static List<UserModel> MapToModelList(List<User> users)
        {
            if (users != null)
            {
                return users.Select(MapToModel).ToList();
            }

            return null;
        }

        public static List<User> MapToEntityList(List<UserModel> userModel)
        {
            if (userModel != null)
            {
                return userModel.Select(MapToEntity).ToList();
            }

            return null;
        }
    }
}
