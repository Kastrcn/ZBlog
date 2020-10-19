using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using marked;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZBlog.Data;
using ZBlog.Model;
using ZBlog.Params;
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
           
            
            IQueryable<Article> articles = from a in _context.Articles
                where a.Status == 1
                orderby a.CreatedAt descending 
                select new Article
                {
                    Id = a.Id,
                    Title = a.Title,
                    Slug = a.Slug,
                    Context = a.Context.ToMarkdown().RemoveTags().SplitTags(),
                    Status = a.Status,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                };
            
            if (!string.IsNullOrEmpty(kw))
            {
                //|| item.Context.Contains(kw)
                articles = articles.Where(item => item.Title.Contains(kw) );
            }

            var articleVos = PaginatedList<Article>
                .CreateAsync(articles.AsNoTracking(),  page ?? 1 , size ?? 10).Result;
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
                _context.Articles.OrderByDescending(item => item.CreatedAt).Select(article => new Article
                        {Title = article.Title, Slug = article.Slug, CreatedAt = article.CreatedAt}).ToList()
                    .GroupBy(archives => archives.CreatedAt.ToString("yyyy-MM"))
                    .Select(item => new Archives {Date = item.Key, List = item.ToList()}).ToList();

            return View(list);
        }

        public IActionResult Links()
        {
            var links = _context.Links.ToList();
            return View(links);
        }

        
        
        public IActionResult About()
        {
            return View();
        }


        // GET

        [Route("post/{slug}")]
        public IActionResult Slug(string slug)
        {

            
            
            
            var article = _context.Articles.Where(item => item.Slug == slug)
                .Select(item => new Article
                {
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    Context = item.Context.ToMarkdown(),
                    Status = item.Status,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                }).First();
            var model=new HomeSlugViewModel(article);
            return View(model);
        }
        
        // GET

        [Route("category/{slug}")]
        public IActionResult Category(string slug,int page,int size)
        {
            var article = _context.Articles.Where(item => item.Slug == slug)
                .Select(item => new Article
                {
                    Id = item.Id,
                    Title = item.Title,
                    Slug = item.Slug,
                    Context = item.Context.ToMarkdown(),
                    Status = item.Status,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                });
            var articleVos = PaginatedList<Article>
                .CreateAsync(article.AsNoTracking(), page | 1, size | 10).Result;

            return View(articleVos);
        }
        
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}