using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Data;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ZBlogContext _context;
        private readonly IMapper _mapper;

        public TagController(ZBlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Admin/Tag
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<TagDto>>(await _context.Tags.ToListAsync()));
        }

        // GET: Admin/Tag/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Admin/Tag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Slug")] TagAddDto tagAddDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<TagAddDto, Tag>(tagAddDto));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tagAddDto);
        }

        // GET: Admin/Tag/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Tag, TagEditDto>(tag));
        }

        // POST: Admin/Tag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Slug")] TagEditDto tagEditDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Tags.SingleOrDefault(item => item.Id == tagEditDto.Id);
                    _mapper.Map<TagEditDto, Tag>(tagEditDto, data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tagEditDto.Id))
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

            return View(tagEditDto);
        }

        // GET: Admin/Tag/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Tag, TagDto>(tag));
        }

        // POST: Admin/Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(long id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}