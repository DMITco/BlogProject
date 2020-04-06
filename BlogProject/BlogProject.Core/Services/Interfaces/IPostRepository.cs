using BlogProject.DataLayer.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Core.Services.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> Add(Post post);
        Task<Post> Find(int id);
        Task<Post> Update(Post post);
        Task<Post> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
