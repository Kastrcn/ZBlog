using ZBlog.Data.Entity;
using ZBlog.Utils;

namespace ZBlog.ViewModel
{
    public class HomeCategoryViewModel
    {
        public PaginatedList<PostViewModel> Posts { get; set; }
        public Category Category { get; set; }
    }
}