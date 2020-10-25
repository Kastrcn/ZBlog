using ZBlog.Data.Entity;
using ZBlog.Utils;

namespace ZBlog.ViewModel
{
    public class HomeTagViewModel
    {
        public PaginatedList<PostViewModel> Posts { get; set; }
        public Tag Tag { get; set; }
    }
}