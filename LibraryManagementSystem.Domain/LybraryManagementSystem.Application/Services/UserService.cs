using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LybraryManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task AddAsync(AddModel userModel)
        {
            var user = UserMappings.MapToEntity(userModel);
            await _userRepository.AddAsync(user);
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
            var users = _userRepository.GetAll();
            return UserMappings.MapToModelList(users);
        }

        public async Task<UserModel> GetByUserNameOrEmail(string username,string email)
        {
            var user = await _userRepository.GetByUserNameOrEmail(username, email);

            return  UserMappings.MapToModel(user);
        }
               
        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(UserModel userModel, LogInModel logInModel)
        {
            string salt = userModel.Salt;
            string hashedPass = userModel.Hash;
            string checkingPass = IdentityHelper.GetHash(logInModel.Password, Convert.FromBase64String(salt));

            if (!hashedPass.Equals(checkingPass))
            {
                return false;
            }

            if (hashedPass != checkingPass)
            {
                return false;
            }

            return true;
        }
        public string GenerateToken(LogInModel logInModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                    new Claim("UserName", logInModel.UserName)
            };

            var token = new JwtSecurityToken(
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: credentials); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }
    }
}
