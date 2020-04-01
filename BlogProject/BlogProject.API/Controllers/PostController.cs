using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BlogProject.Core.Services.Interfaces;
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
        public IActionResult GetPost()
        {
            try
            {
                var Posts = _postRepository.GetPosts();
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

        [HttpGet("{id}")]
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
                    return BadRequest(ModelState);
                }

                await _postRepository.Add(Post);
                return CreatedAtAction(nameof(GetPost), new { id = Post.PostId }, Post);
            }
            catch (Exception ex)
            {

                 return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] Post Post)
        {
            try
            {
                await _postRepository.Update(Post);
                return Ok(Post);
            }
            catch (Exception ex)
            {

                 return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            try
            {
                await _postRepository.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {

                 return new JsonResult(new { message = ex.Message }) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }

        }
    }
}