using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.ResponseModel;
using LybraryManagementSystem.Application.Models.User;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;
        private readonly ICacheService _cacheService;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IMemoryCache cache, ICacheService cacheService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _cache = cache;
            _cacheService = cacheService;
        }

        public async Task<OperationResultModel> LogInAsync(LogInModel logInModel)
        {
            var user = await _userRepository.GetByUserName(logInModel.UserName);

            if (user == null)
            {
                return new OperationResultModel()
                {
                    Success = false,
                    Result = null,
                    Error = "The account wasn't found",
                };
            }

            if (!ValidateUser(user, logInModel))
            {
                return new OperationResultModel()
                {
                    Success = false,
                    Result = null,
                    Error = "Invalid password",
                };
            }

            var token = GenerateToken(logInModel);

            var dbUser = await _userRepository.GetByUserName(user.UserName);
             _cacheService.SetData<LogInModel>(dbUser.UserName, logInModel);

            return new OperationResultModel()
            {
                Success = true,
                Result = token,
                Error = null,
            };
        }

        public async Task AddAsync(AddUserModel userModel)
        {
            var user = UserMappings.MapToEntity(userModel);
            await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user.Id);
            }
        }

        public async Task<UserModel> GetByIdAsync(int userId)
        {
            var key = $"userId_{userId}";
            var user = _cacheService.GetData<UserModel>(key);

            if (user == null)
            {
                var dbUser = await _userRepository.GetByIdAsync(userId);
                user = UserMappings.MapToModel(dbUser);
                user = _cacheService.SetData<UserModel>(key, user);
            }

            return user;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return UserMappings.MapToModelList(users);
        }

        public async Task<UserModel> GetByUserName(string username)
        {
            var key = $"userName_{username}";
            var user = _cacheService.GetData<UserModel>(key);
            if (user == null)
            {
                var dbUser = await _userRepository.GetByUserName(username);
                user = UserMappings.MapToModel(dbUser);
                user = _cacheService.SetData<UserModel>(key, user);
            }

            return user;
        }

        public async Task UpdateAsync(UserModel userModel)
        {
            var user = UserMappings.MapToEntity(userModel);
            await _userRepository.UpdateAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync();
        }

        // Private methods
        private bool ValidateUser(User userModel, LogInModel logInModel)
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
        private string GenerateToken(LogInModel logInModel)
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
    }
}
