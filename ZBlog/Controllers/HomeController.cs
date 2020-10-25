using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using marked;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZBlog.Config;
using ZBlog.Data;
using ZBlog.Data.Entity;
using ZBlog.Model;
using ZBlog.Utils;
using ZBlog.ViewModel;
using ZBlog.VO;

namespace ZBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ZBlogContext _context;


        public HomeController(ILogger<HomeController> logger, ZBlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? page, int? size, string kw)
        {
            IQueryable<Article> articles = from a in _context.Posts
                where a.Status == PostType.Publish
                orderby a.CreateTime descending
                select new Article
                {
                    Id = a.Id,
                    Title = a.Title,
                    Slug = a.Slug,
                    Context = a.Context.ToMarkdown().RemoveTags().SplitTags(),
                    // Status = a.Status.,
                    CreatedAt = a.CreateTime,
                    UpdatedAt = a.CreateTime,
                };

            if (!string.IsNullOrEmpty(kw))
            {
                //|| item.Context.Contains(kw)
                articles = articles.Where(item => item.Title.Contains(kw));
            }

            var articleVos = PaginatedList<Article>
                .CreateAsync(articles.AsNoTracking(), page ?? 1, size ?? 10).Result;
            return View(articleVos);
        }


        public IActionResult Post()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Archives()
        {
            var list =
                _context.Posts.OrderByDescending(item => item.CreateTime).Select(article => new Article
                        {Title = article.Title, Slug = article.Slug, CreatedAt = article.CreateTime}).ToList()
                    .GroupBy(archives => archives.CreatedAt.ToString("yyyy-MM"))
                    .Select(item => new Archives {Date = item.Key, List = item.ToList()}).ToList();

            return View(list);
        }

        public IActionResult Links()
        {
             var links = _context.Links.ToList();
             return View(links);
        }


        public async Task<IActionResult> About()
        {
           var config =await _context.Configs.FirstOrDefaultAsync(id => SysConfig.About == id.Name);
            return View(config);
        }


        // GET

        [Route("post/{slug}")]
        public IActionResult Slug(string slug)
        {
            var article = _context.Posts.Where(item => item.Slug == slug)
                .Select(item => new Article
                {
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    Context = item.Context.ToMarkdown(),
                    // Status = item.Status.,
                    CreatedAt = item.CreateTime,
                    UpdatedAt = item.CreateTime,
                }).First();
            var model = new HomeSlugViewModel(article);
            return View(model);
        }

        // GET

        [Route("category/list/{slug}")]
        public async Task<IActionResult> Category(string slug, int page, int size)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(item => item.Slug == slug);
            var post = _context.Posts.Where(item => item.CategoryId == category.Id)
                .Select(item => new PostViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    Context = item.Context.ToMarkdown(),
                    Status = item.Status,
                    CreatedAt = item.CreateTime,
                    UpdatedAt = item.UpdateTime,
                });
            
            var posts = PaginatedList<PostViewModel>
                .CreateAsync(post.AsNoTracking(), page | 1, size | 10).Result;

            var homeCategoryViewModel = new HomeCategoryViewModel();
            homeCategoryViewModel.Posts = posts;
            homeCategoryViewModel.Category = category;
            return View(homeCategoryViewModel);
        }

        
        [Route("tag/list/{slug}")]
        public async Task<IActionResult> Tag(string slug, int page, int size)
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(item => item.Slug == slug);
           var post= _context.PostTags.Include(p => p.Post).Where(p => p.TagId == tag.Id).Select(item=>new PostViewModel
           {
               Id = item.Post.Id,
               Title = item.Post.Title,
               Slug = item.Post.Slug,
               Context = item.Post.Context.ToMarkdown(),
               Status = item.Post.Status,
               CreatedAt = item.Post.CreateTime,
               UpdatedAt = item.Post.UpdateTime,
           });
           var posts = PaginatedList<PostViewModel>
                .CreateAsync(post.AsNoTracking(), page | 1, size | 10).Result;
           var homeCategoryViewModel = new HomeTagViewModel();
            homeCategoryViewModel.Posts = posts;
            homeCategoryViewModel.Tag = tag;
            return View(homeCategoryViewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult Tags()
        {
            var tags = _context.Tags.ToList();

            return View(tags);
        }
    }
}