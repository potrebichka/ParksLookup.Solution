﻿using ParksLookup.Dtos;
using ParksLookup.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParksLookup.Services
{
    public class AccountService
    {
        private readonly IEnumerable<User> _users = new List<User>
        {
            new User { Id = 1, Username = "fred", Password = "123", Role = "Administrator"},
            new User { Id = 2, Username = "alice", Password = "456", Role = "Accountant"},
            new User { Id = 3, Username = "joe", Password = "789", Role = "Guest"},
            new User { Id = 4, Username = "11@11.com", Password = "1q2w3e", Role = "Guest"},
            new User { Id = 5, Username = "22@22.com", Password = "1q2w3e", Role = "Administrator"},
        };

        private readonly IConfiguration _configuration;

        public AccountService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Login(LoginDto loginDto)
        {
            var user = _users.Where(x => x.Username == loginDto.Username && x.Password == loginDto.Password).SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            var signingKey = Convert.FromBase64String(_configuration["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("userid", user.Id.ToString()),
                        new Claim("role", user.Role)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}