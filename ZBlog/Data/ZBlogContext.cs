using Microsoft.EntityFrameworkCore;

namespace ZBlog.Data
{
    public class ZBlogContext : DbContext
    {
        public ZBlogContext(
            DbContextOptions<ZBlogContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Article> Articles { get; set; }
        public DbSet<Model.Comment> Comments { get; set; }
    }
}