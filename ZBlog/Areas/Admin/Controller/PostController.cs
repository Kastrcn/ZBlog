using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Areas.Admin.ViewModel;
using ZBlog.Config;
using ZBlog.Data;
using ZBlog.Data.Entity;
using ZBlog.Model;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly ZBlogContext _context;
        private readonly IMapper _mapper;

        public PostController(ZBlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Admin/Post
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PostListDto>>(await _context.Posts.Include(p => p.PostTags)
                .ThenInclude(p => p.Tag)
                .OrderByDescending(a => a.CreateTime).ToListAsync()));
        }

        // GET: Admin/Post/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(item => item.PostTags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(_mapper.Map<Post, PostDto>(post));
        }

        // GET: Admin/Post/Create
        public IActionResult Create()
        {
            ViewBag.PostType = from PostType d in Enum.GetValues(typeof(PostType))
                select new {Id = (int) d, Name = d.ToString()};

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }

        // POST: Admin/Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Title,Slug,Context,Status,CategoryId,TagIds,CreateTime,UpdateTime")]
            PostAddDto postAddDto)
        {
            if (ModelState.IsValid)
            {
                var post = new Post();
                post.CategoryId = postAddDto.CategoryId;
                post.Slug = postAddDto.Slug;
                post.Title = postAddDto.Title;
                post.Context = postAddDto.Context;
                post.Status = postAddDto.Status;
                post.CreateTime = postAddDto.CreateTime ?? DateTime.Now;
                post.UpdateTime = postAddDto.UpdateTime ?? DateTime.Now;
                post.AccountId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                post.PostTags = postAddDto.TagIds.Select(item => new PostTag {TagId = item}).ToList();
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.PostType = from PostType d in Enum.GetValues(typeof(PostType))
                select new {Id = (int) d, Name = d.ToString()};

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(postAddDto);
        }

        // GET: Admin/Post/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post =await _context.Posts.Include(p=>p.PostTags).FirstOrDefaultAsync(p=>p.Id==id);
            if (post == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View(_mapper.Map<Post, PostEditDto>(post));
        }

        // POST: Admin/Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] PostEditDto postEditDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Posts.Include(p=>p.PostTags).SingleOrDefault(item => item.Id == postEditDto.Id);


                    data.CategoryId = postEditDto.CategoryId;
                    if (postEditDto.Slug != null)
                    {
                        data.Slug = postEditDto.Slug;
                    }

                    if (postEditDto.Title != null)
                    {
                        data.Title = postEditDto.Title;
                    }

                    if (postEditDto.Context != null)
                    {
                        data.Context = postEditDto.Context;
                    }

                    data.Status = postEditDto.Status;


                    data.CreateTime = postEditDto.CreateTime ?? DateTime.Now;
                    data.UpdateTime = postEditDto.UpdateTime ?? DateTime.Now;
                    // if(post)
                    if (postEditDto.TagIds!=null)
                    {
                     
                        data.PostTags = postEditDto.TagIds.Select(item => new PostTag {TagId = item}).ToList();
                    }
                    
                    var list=  _context.PostTags.Where(item=>item.PostId==postEditDto.Id);
                    foreach (var postTag in list)
                    {
                        _context.PostTags.Remove(postTag);
                    }
                    
                   

                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(postEditDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(postEditDto);
        }

        // GET: Admin/Post/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var article = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(long id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}