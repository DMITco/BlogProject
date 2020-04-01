using BlogProject.DataLayer.Entities.Post;
using BlogProject.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.DataLayer.Context
{
    public class BlogProjectContext : DbContext
    {
        public BlogProjectContext(DbContextOptions<BlogProjectContext> options) : base(options)
        {
        }



        #region User
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserToRole> UserRoles { get; set; }
        #endregion

        #region Post
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostGroup> PostGroup { get; set; }
        public virtual DbSet<PostToPostGroup> PostToPostGroup { get; set; }
        #endregion

    }
}
