using System.Collections.Generic;
using System.Threading.Tasks;
using ZBlog.Model;
using ZBlog.Utils;
using ZBlog.VO;

namespace ZBlog.RO
{
    
    public class HomeIndexRo
    {
        public PaginatedList<Article> ArticleVos { get; set; }
        public List<Article> ArticleLatest{ get; set; }
        public List<Article> ArticleComment{ get; set; }
    }
}