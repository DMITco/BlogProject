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
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToRole> UserRoles { get; set; }
        #endregion

        #region Post
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostGroup> PostGroup { get; set; }
        #endregion
    }
}
