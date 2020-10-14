using System.Collections.Generic;
using ZBlog.VO;

namespace ZBlog.Service
{
    public interface IHomeService
    {
        List<ArticleVo> GetArticlePageList();
    }
}