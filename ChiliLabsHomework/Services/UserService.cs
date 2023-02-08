using Ajax;
using ChiliLabsHomework.Data;
using ChiliLabsHomework.Models;
using ChiliLabsHomework.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ChiliLabsHomework.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public JSend Registration(string nickname, string password)
        {
            // Check if the specified nickname already exists in the database
            if (_context.DbUsers.Any(u => u.Nickname == nickname))
            {
                return JSend.Error("The specified nickname is already in use. Please choose another one.");
            }

            // Create a new User object with the specified nickname and password
            UserModel user = new UserModel
            {
                Nickname = nickname,
                Password = password,
            };

            // Hash and salt the password
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Add the new user to the database
            _context.DbUsers.Add(user);
            _context.SaveChanges();

            // Generate a JWT token for the newly registered user
            string token = GenerateHandlerToken(user.UserId, nickname);

            // Return a JSend success response with the generated token
            return JSend.Success(new { token });
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private string GenerateHandlerToken(int userId, string nickname)
        {
            // Define the claims for the JWT token
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, nickname),
            });

            // Extract the claims from the ClaimsIdentity
            IEnumerable<Claim> claims = claimsIdentity.Claims;

            // Define the JWT security key and signing credentials
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yoursecretkeyhere"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Define the JWT security token descriptor
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "yourissuerhere",
                audience: "youraudiencehere",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            // Return the JWT token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public JSend Login(string identifier, string password)
        {
            var user = _context.DbUsers.FirstOrDefault(u => u.Nickname == identifier);
            if (user == null)
            {
                return JSend.Error("User not found.");
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return JSend.Error("Incorrect password.");
            }

            var token = GenerateTokenForUser(user);
            return JSend.Success(new { Token = token });
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string GenerateTokenForUser(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("yoursecretkeywith16orMoreBytes");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Nickname)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
