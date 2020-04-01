using BlogProject.Core.Services.Interfaces;
using BlogProject.DataLayer.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services
{
    public class PostRepository : IPostRepository
    {
        public Task<Post> Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
