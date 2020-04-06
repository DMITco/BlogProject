using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogProject.Core.Services.Interfaces;
using BlogProject.Core.Utilities;
using BlogProject.DataLayer.Entities.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            try
            {
                var Posts = await _postRepository.GetPosts();
                if (Posts.Any())
                {
                    return Ok(Posts);
                }
                return NotFound(new { message = "هنوز پستی درج نشده است" });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }
        [HttpGet("{PageNumber:int}/{PageSize:int}")]
        public async Task<IActionResult> GetPost(int PageNumber, int PageSize)
        {
            try
            {
                var Posts = await _postRepository.GetPosts(PageNumber, PageSize);
                if (Posts.Any())
                {
                    return Ok(Posts);
                }
                return NotFound(new { message = "هنوز پستی درج نشده است" });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            try
            {
                if (await _postRepository.IsExists(id))
                {

                    var Post = await _postRepository.Find(id);
                    return Ok(Post);
                }
                else
                {
                    return NotFound(new { message = "پستی با این شناسه پیدا نشد" });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] Post Post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { message = ErrorHandeling.MessageBadRequest(ModelState) });
                }

                await _postRepository.Add(Post);
                return CreatedAtAction(nameof(GetPost), new { id = Post.PostId }, Post);
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }


        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] Post Post)
        {
            try
            {
                if (id != Post.PostId)
                {
                    return BadRequest(ErrorHandeling.MessageBadRequest("شناسه ارسالی با شناسه کاربر یکی نیست"));
                }
                await _postRepository.Update(Post);
                return Ok(Post);
            }
            catch (Exception ex)
            {

                return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            try
            {
                var result = await _postRepository.Remove(id);
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