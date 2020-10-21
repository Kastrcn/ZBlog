using ZBlog.Model;
using ZBlog.Utils;

namespace ZBlog.ViewModel
{
    public class HomeCategoryViewModel
    {
        public PaginatedList<Article> Articles { get; set; }
        public Category Category { get; set; }
    }
}