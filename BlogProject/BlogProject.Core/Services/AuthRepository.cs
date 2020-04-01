using BlogProject.Core.Configuration;
using BlogProject.Core.Models;
using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
{
    public class AuthRepository : IAuthRepository
    {

        private readonly AppSettings _appSettings;
        private BlogProjectContext _context;

        public AuthRepository(IOptions<AppSettings> appSettings, BlogProjectContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public async Task<Auth> Authenticate(Login login)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == login.UserName && x.Password == login.Password);

            // return null if user not found
            if (user == null)
                return null;


            var Roles = await _context.UserRoles.Where(x => x.UserId == user.UserId).ToListAsync();

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            foreach (var permission in Roles)
            {
                claims.AddClaims(new[]
                            {
                new Claim(ClaimTypes.Role, permission.RoleId.ToString())
            });
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            // user.Password = null;

            return new Auth() { Token = tokenHandler.WriteToken(token) };
        }
    }
}
