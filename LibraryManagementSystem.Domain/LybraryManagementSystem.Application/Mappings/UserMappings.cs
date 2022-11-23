using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Models;
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
                FirstName = userModel.Name,
            };
        }

        public static User MapToEntity(AddModel addModel)
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
                FirstName = "Gago",
                LastName = "Gago",
            };
        }

        public static User LogInMapToEntity(LogInModel logInModel)
        {
            return new User
            {
                FirstName = logInModel.UserName,
            };
        }
        //inverse mapper
        public static UserModel MapToModel(User user)
        {
            //if (user != null)
            //{
            //    return new UserModel
            //    {
            //        Name = user.Name,
            //        Password = user.Password,
            //    };
            //}

            var config = new MapperConfiguration(c =>
                c.CreateMap<User, UserModel>());
            var mapper = new Mapper(config);
            var mappedUser = mapper.Map<UserModel>(user);

            return mappedUser;
        }

        public static LogInModel LogInMapToModel(User user)
        {
            return new LogInModel
            {
                UserName = user.FirstName,
            };
        }
    }
}
