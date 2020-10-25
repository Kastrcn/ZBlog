using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZBlog.Data.Configurations;
using ZBlog.Data.Entity;
using ZBlog.Model;
using Account = ZBlog.Data.Entity.Account;

namespace ZBlog.Data
{
    public class ZBlogContext : DbContext
    {
        public ZBlogContext(DbContextOptions<ZBlogContext> options)
            : base(options)
        {
        }

        public DbSet<Entity.Account> Accounts { get; set; }
        public DbSet<Entity.Category> Categories { get; set; }
        public DbSet<Entity.Post> Posts { get; set; }
        public DbSet<Entity.Comment> Comments { get; set; }
        public DbSet<Entity.Link> Links { get; set; }

        public DbSet<Entity.Tag> Tags { get; set; }
        
        public  DbSet<Entity.PostTag> PostTags { get; set; }
        public  DbSet<Entity.Config> Configs { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostTagConfiguration());

          
            builder.Entity<Account>().HasData(new Account()
            {
                Id = 1,
                UserName = "tian",
                Password = "zhao",
                Email = "kastrcn@outlook.com",
                NickName = "tian",
                CreateTime = DateTime.Now, UpdateTime = DateTime.Now
            });


            base.OnModelCreating(builder);
        }
    }
}