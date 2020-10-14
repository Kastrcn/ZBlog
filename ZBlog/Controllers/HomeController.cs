using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZBlog.Model;
using ZBlog.Params;
using ZBlog.RO;
using ZBlog.Service;
using ZBlog.Service.impl;
using ZBlog.VO;

namespace ZBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index(HomeIndexParam homeIndexParam)
        {
            var homeIndexRo = new HomeIndexRo();
            homeIndexRo.ArticleVos = await _homeService.GetArticlePageList(homeIndexParam);
            homeIndexRo.ArticleLatest = await _homeService.GetArticleLatest();
            homeIndexRo.ArticleComment = null; // await  _homeService.GetArticleComments();
            // Post.where(:status=>1).left_joins(:comments).group("post_id").order("count(post_id) desc").limit(5)
            return View(homeIndexRo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Archives()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}