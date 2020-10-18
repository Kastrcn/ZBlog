using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZBlog.Model;

namespace ZBlog.Data
{
    public class ZBlogContext :  DbContext
    {
      
        public ZBlogContext(DbContextOptions<ZBlogContext> options)
            : base(options)
        {
        }
      

        public DbSet<Model.Article> Articles { get; set; }
        public DbSet<Model.Comment> Comments { get; set; }
        public DbSet<Model.Link> Links { get; set; }
        public DbSet<Model.Category> Categories { get; set; }
        
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //     builder.Entity<Account>().ToTable("account");
        // }
    }
}