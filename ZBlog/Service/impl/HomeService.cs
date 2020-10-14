using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ZBlog.Data;
using ZBlog.Model;
using ZBlog.Params;
using ZBlog.Utils;
using ZBlog.VO;

namespace ZBlog.Service.impl
{
    public class HomeService : IHomeService
    {
        private readonly ZBlogContext _context;

        public HomeService(ZBlogContext context)
        {
            _context = context;
        }

        public Task<PaginatedList<Article>> GetArticlePageList(HomeIndexParam homeIndexParam)
        {
            var orderedQueryable =
                _context.Articles.Where(item => item.Status == 1).OrderBy(article => article.CreatedAt);

            return PaginatedList<Article>
                .CreateAsync(orderedQueryable.AsNoTracking(), homeIndexParam);
        }

        public Task<List<Article>> GetArticleLatest()
        {
            return _context.Articles.Where(item => item.Status == 1).OrderBy(article => article.UpdatedAt).Take(5)
                .ToListAsync();
        }

        public Task<List<IGrouping<long, Comment>>> GetArticleComments()
        {
            //        @comments_postis=Post.where(:status=>1).left_joins(:comments).group("post_id").order("count(post_id) desc").limit(5)

            var students = from p1 in _context.Articles
                where p1.Status.Equals(1)
                join p2 in _context.Comments on p1.Id equals p2.ArticleId
                group p2 by p2.ArticleId
                into g
                orderby g.Sum(t=>t.ArticleId)
                select g;

            return students.Take(5).ToListAsync();
            // return _context.Articles.Where(item => item.Status == 1).LeftJoin("comments").GroupBy("post_id").OrderBy(article => ).Take(5)
            //     .ToListAsync();
        }
    }
}