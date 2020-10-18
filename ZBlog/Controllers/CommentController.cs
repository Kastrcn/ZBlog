using Microsoft.AspNetCore.Mvc;
using ZBlog.Params;

namespace ZBlog.Controllers
{
    public class CommentController : Controller
    {
        // GET
        public IActionResult Index([Bind("PostId,UserName,Nickname,Website")] CommentParam commentParam)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(comment);
                // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // return View(commentParam);
            return null;

        }
    }
}