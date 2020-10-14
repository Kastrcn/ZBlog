using System.Collections.Generic;
using ZBlog.VO;

namespace ZBlog.Service.impl
{
    public class HomeService : IHomeService
    {
        public List<ArticleVo> GetArticlePageList()
        {
            var articleVos = new List<ArticleVo>();
            for (var i = 0; i < 5; i++)
            {
                articleVos.Add(new ArticleVo()
                {
                    Title = $"title{i}",
                    Context = $"context{i}"
                });
            }

            return articleVos;
        }
    }
}