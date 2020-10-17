using System.Linq;
using marked;
using Microsoft.AspNetCore.Mvc;
using ZBlog.Data;
using ZBlog.Model;
using ZBlog.Utils;

namespace ZBlog.Controllers
{
    public class PostController : Controller
    {
        private ZBlogContext _context;

        public PostController(ZBlogContext context)
        {
            _context = context;
        }


        // GET
        public IActionResult Index()
        {
            return View();
        }


    }
}