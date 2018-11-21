using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Helpers;

namespace PetShop.RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginInputModel model)
        {
            var user = _userService.GetUser(model.Username);
            if (user == null)
                return Unauthorized();

            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            return Ok(new
            {
                username = user.Username,
                token = GenerateToken(user)
            });
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            if (user.AccessLvl == 0)
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    JwtSecurityKey.Key,
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null,
                    null,
                    claims.ToArray(),
                    DateTime.Now, 
                    DateTime.Now.AddDays(1)));
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}