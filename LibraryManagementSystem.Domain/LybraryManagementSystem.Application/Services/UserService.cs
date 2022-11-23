using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models;
using System.Security.Cryptography;
using System.Text;

namespace LybraryManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(AddModel userModel)
        {
            var user = UserMappings.MapToEntity(userModel);
             _userRepository.Add(user);
        }

        public UserModel Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _userRepository.Delete(user.Id);
            }

            return user;
        }

        public UserModel GetById(int userId)
        {
            var user = _userRepository.GetById(userId);

            return UserMappings.MapToModel(user);
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUserName(string username)
        {
            var user = _userRepository.GetByUserName(username);

            return UserMappings.MapToModel(user);
        }

        public UserModel Update(UserModel user)
        {
            throw new NotImplementedException();
        }

        private bool Validation(string username, string password)
        {
            //if (user != null)
            //{
            //    return user.password.equals(password);
            //}

            return false;
        }

       
    }
}
