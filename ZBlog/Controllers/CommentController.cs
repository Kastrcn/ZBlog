using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZBlog.Data;
using ZBlog.Model;
using ZBlog.Params;
using ZBlog.ViewModel;

namespace ZBlog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ZBlogContext _context;

        public CommentController(ZBlogContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index([Bind("PostId,UserName,Nickname,Website")]
            CommentParam commentParam)
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

        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Comment
                {
                    Content = commentViewModel.Content,
                    PostId = commentViewModel.PostId,
                    Email = commentViewModel.Email,
                    NickName = commentViewModel.NickName,
                    WebSite = commentViewModel.WebSite,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                });
                await _context.SaveChangesAsync();
                return Json(new { a="123" });
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new { });
            // return Json(new CommentResponse(false, CommentResponseCode.InvalidModel));

            // var commentPostModel = model.NewCommentViewModel;
            // var response = await _commentService.CreateAsync(new NewCommentRequest(commentPostModel.PostId)
            // {
            //     Username = commentPostModel.Username,
            //     Content = commentPostModel.Content,
            //     Email = commentPostModel.Email,
            //     IpAddress = HttpContext.Connection.RemoteIpAddress.ToString()
            // });


            return Json(new { });
        }
    }
}