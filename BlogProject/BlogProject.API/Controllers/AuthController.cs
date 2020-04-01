using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogProject.API.Models;
using BlogProject.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        IUserRepository _userRepository;
        IAuthRepository _authRepository;

        public AuthController(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("The Model Is Not Valid");
            }


            var User = _userRepository.FindByUserPass(new Core.Models.Login() { UserName = login.UserName, Password = login.Password }).Result;
            if (User != null)
            {
                if (User.IsActice)
                {
                    var token = await _authRepository.Authenticate(new Core.Models.Login() { UserName = User.UserName, Password = User.Password });

                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return NotFound();
            }





        }
    }
}