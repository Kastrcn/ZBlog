using System;
using System.Collections.Generic;
using ZBlog.Model;

namespace ZBlog.VO
{
    public class Archives
    {
        public string Date { get; set; }
        public List<Article> List { get; set; }
    }
}