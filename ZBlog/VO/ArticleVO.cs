using System;

namespace ZBlog.VO
{
    public class ArticleVo
    {
        public string Title { get; set; }
        public string  Context { get; set; }
        public int  Type { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}