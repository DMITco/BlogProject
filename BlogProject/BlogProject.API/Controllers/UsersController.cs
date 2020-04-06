using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogProject.Core.Services.Interfaces;
using BlogProject.Core.Utilities;
using BlogProject.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1")]
    public class UsersController : ControllerBase
    {
        IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// گرفتن تمام کاربران
        /// </summary>
        /// <returns>Users</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var Users = await _userRepository.GetUsers();
                if (Users.Any())
                {
                    return Ok(Users);
                }

                return NotFound(new { message = "هیچ کاربری پیدا نشد" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }
        [HttpGet("{PageNumber:int}/{PageSize:int}")]
        public async Task<IActionResult> GetUsers(int PageNumber, int PageSize )
        {
            try
            {
                var Users = await _userRepository.GetUsers(PageNumber, PageSize);
                if (Users.Any())
                {
                    return Ok(Users);
                }

                return NotFound(new { message = "هیچ کاربری پیدا نشد" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }
        [HttpGet("{id:int}")]
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
                    return NotFound(new { message = "کاربری با این مشخصات پیدا نشد" });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User User)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //ForExam
                    // var Errors = ModelState.Values.Select(e => e.Errors.Select(e => e.ErrorMessage).FirstOrDefault()).ToList();
                    return BadRequest(new { message = ErrorHandeling.MessageBadRequest(ModelState) });
                }

                var IsExist = _userRepository.IsExistsByUserName(User.UserName);
                if (IsExist.Result)
                {
                    return new JsonResult(new { message = "کاربری با این نام کاربری وجود دارد" }) { StatusCode = (int)HttpStatusCode.Conflict };
                }

                await _userRepository.Add(User);
                // await _userRepository.AddRole(User.UserId,1);
                return CreatedAtAction(nameof(GetUser), new { id = User.UserId }, User);
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }


        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User User)
        {
            try
            {
                if (User ==null || id != User.UserId)
                {
                    return BadRequest(ErrorHandeling.MessageBadRequest("شناسه ارسالی با شناسه کاربر یکی نیست"));
                }

                await _userRepository.Update(User);
                return Ok(User);
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                var result = await _userRepository.Remove(id);
                if (result == null)
                {
                    return NotFound(new { message = "کاربری با این مشخصات پیدا نشد" });
                }
                return Ok(new { message = "کاربر حذف شد" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }
    }
}