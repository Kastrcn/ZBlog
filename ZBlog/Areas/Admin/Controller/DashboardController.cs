using Microsoft.AspNetCore.Mvc;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}