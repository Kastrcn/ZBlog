using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Areas.Admin.Params;
using ZBlog.Data;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ZBlogContext _context;
        private readonly IMapper _mapper;

        public CategoryController(ZBlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            ;

            return View(_mapper.Map<IEnumerable<CategoryListDto>>(await _context.Categories.ToListAsync()));
        }


        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Category, CategoryDto>(category));
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Slug")] CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryAddDto);
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categoryAddDto);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

        
            
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CategoryEditDto>(category));
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Slug")] CategoryEditDto categoryEditDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Categories.SingleOrDefault(item => item.Id == categoryEditDto.Id);
                    _mapper.Map<CategoryEditDto,Category>(categoryEditDto,data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(categoryEditDto.Id))
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

            return View(categoryEditDto);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Category, CategoryDto>(category));
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(long id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}