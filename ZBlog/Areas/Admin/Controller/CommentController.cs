using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZBlog.Areas.Admin.ViewModel;
using ZBlog.Data;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ZBlogContext _context;
        private readonly IMapper _mapper;

        public CommentController(ZBlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Admin/Comment
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments.ToListAsync());
        }

        // GET: Admin/Comment/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Admin/Comment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Comment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostId,Content,Reply,CreateTime,UpdateTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // GET: Admin/Comment/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var commentEditViewModel = _mapper.Map<Comment,CommentEditViewModel>(comment);
            return View(commentEditViewModel);
        }

        // POST: Admin/Comment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [FromForm] CommentEditViewModel commentEditViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var comment = await _context.Comments.SingleAsync(item => item.Id == commentEditViewModel.Id);
                    var data = _mapper.Map<CommentEditViewModel, Comment>(commentEditViewModel,comment);
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(commentEditViewModel.Id))
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
            return View(commentEditViewModel);
        }

        // GET: Admin/Comment/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Admin/Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
