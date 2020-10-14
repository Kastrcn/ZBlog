using System;

namespace ZBlog.Model
{
    public class Article
    {
        public string Title { get; set; }
        public string  Context { get; set; }
        public int  Type { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}