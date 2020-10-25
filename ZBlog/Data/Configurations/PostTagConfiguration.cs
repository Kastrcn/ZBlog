using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZBlog.Data.Entity;

namespace ZBlog.Data.Configurations
{
    internal class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder
                .HasKey(bc => new {bc.PostId, bc.TagId});
            builder
                .HasOne(bc => bc.Post)
                .WithMany(b => b.PostTags)
                .HasForeignKey(bc => bc.PostId);
            builder
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.PostTags)
                .HasForeignKey(bc => bc.TagId);
        }
    }
}