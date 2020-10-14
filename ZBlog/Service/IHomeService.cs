using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZBlog.Model;
using ZBlog.Params;
using ZBlog.Utils;
using ZBlog.VO;

namespace ZBlog.Service
{
    public interface IHomeService
    {
        Task<PaginatedList<Article>> GetArticlePageList(HomeIndexParam homeIndexParam);
        Task<List<Article>> GetArticleLatest();
        Task<List<IGrouping<long, Comment>>> GetArticleComments();
    }
}