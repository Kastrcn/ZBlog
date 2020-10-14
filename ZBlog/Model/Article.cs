using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZBlog.Model
{
    [Table("article")]
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Context { get; set; }
        public int Status { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}