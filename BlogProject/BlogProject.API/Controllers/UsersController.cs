using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogProject.API.Services.interfaces;
using BlogProject.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                var Users = _userRepository.GetUsers();
                if (Users.Any())
                {
                    return Ok(Users);
                }
                return NoContent(/*new { message = "کاربری پیدا نشد" }*/);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            try
            {
                if (await _userRepository.IsExists(id))
                {

                    var User = await _userRepository.Find(id);
                    return Ok(User);
                }
                else
                {
                    return NoContent(/*new { message = "کاربر پیدا نشد" }*/);
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User User)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _userRepository.Add(User);
                return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User User)
        {
            try
            {
                await _userRepository.Update(User);
                return Ok(User);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                await _userRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
    }
}