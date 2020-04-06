using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Context;
using BlogProject.DataLayer.Entities.Post;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
{
    public class PostRepository : IPostRepository
    {
        private BlogProjectContext _context;

        public PostRepository(BlogProjectContext context)
        {
            _context = context;
        }
        public async Task<Post> Add(Post post)
        {
            try
            {
                await _context.Posts.AddAsync(post);
                await _context.SaveChangesAsync();
                return post;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<Post> Find(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(u => u.PostId == id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _context.Posts.AnyAsync(u => u.PostId == id);
        }

        public async Task<Post> Remove(int id)
        {
            var user = await _context.Posts.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            _context.Posts.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Post> Update(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }
    }
}
