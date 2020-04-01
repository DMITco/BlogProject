using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary1.Models
{
    public partial class BlogProject_DBContext : DbContext
    {
        public BlogProject_DBContext()
        {
        }

        public BlogProject_DBContext(DbContextOptions<BlogProject_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PostGroup> PostGroup { get; set; }
        public virtual DbSet<PostToPostGroup> PostToPostGroup { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.Property(e => e.GroupTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PostToPostGroup>(entity =>
            {
                entity.HasKey(e => e.PpgId);

                entity.HasIndex(e => e.PostId);

                entity.Property(e => e.PpgId).HasColumnName("PPG_Id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.PostToPostGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostToPostGroup_PostGroup");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostToPostGroup)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostToPostGroup_Posts");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.HasIndex(e => e.UserCreateId)
                    .HasName("IX_Posts_UserId");

                entity.Property(e => e.PostText).IsRequired();

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.HasOne(d => d.UserCreate)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserCreateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Users");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.UrId);

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UrId).HasColumnName("UR_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.ActiveCode).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserAvatar).HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
