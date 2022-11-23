using LybraryManagementSystem.Application.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Helper
{
    public class IdentityHelper
    {
        private readonly IConfiguration _configuration;

        public IdentityHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string GetHash(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public static byte[] GetSalt()
        {
            return RandomNumberGenerator.GetBytes(128 / 8);
        }
    }
}
