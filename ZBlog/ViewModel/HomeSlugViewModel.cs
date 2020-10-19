using ZBlog.Model;

namespace ZBlog.ViewModel
{
    public class HomeSlugViewModel
    {
        public Article Article { get; set; }
        public CommentViewModel CommentViewModel { get; set; }

        public HomeSlugViewModel()
        {
            
        }

        public HomeSlugViewModel(Article article)
        {
            Article = article;
            CommentViewModel=new CommentViewModel(){PostId = Article.Id};
            
        }
    }
}