using Microsoft.AspNetCore.Mvc;

namespace ZBlog.Controllers
{
    public class SystemConfigController:Controller
    {
        
        [Route("install")]
        public IActionResult Install()
        {
            return View();
        }
        
    }
}