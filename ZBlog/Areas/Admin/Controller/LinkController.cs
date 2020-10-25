using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZBlog.Areas.Admin.Dtos;
using ZBlog.Data;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    [Authorize]
    public class LinkController : Controller
    {
        private readonly ZBlogContext _context;
        private readonly IMapper _mapper;

        public LinkController(ZBlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Admin/Link
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<LinkListDto>>(await _context.Links.ToListAsync()));
        }

        // GET: Admin/Link/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .FirstOrDefaultAsync(m => m.Id == id);
            if (link == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<LinkDto>(link));
        }

        // GET: Admin/Link/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Link/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Logo,Name,Priority,Url,Description")]
            LinkAddDto linkAddDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Link>(linkAddDto));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(linkAddDto);
        }

        // GET: Admin/Link/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Link, LinkEditDto>(link));
        }

        // POST: Admin/Link/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,
            [Bind("Id,Logo,Name,Priority,Team,Url,Description,CreateTime,UpdateTime")]
            LinkEditDto linkEditDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.Links.SingleOrDefault(item => item.Id == linkEditDto.Id);
                    _mapper.Map<LinkEditDto,Link>(linkEditDto,data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(linkEditDto.Id))
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

            return View(linkEditDto);
        }

        // GET: Admin/Link/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var link = await _context.Links
                .FirstOrDefaultAsync(m => m.Id == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Link, LinkDto>(link));
        }

        // POST: Admin/Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var link = await _context.Links.FindAsync(id);
            _context.Links.Remove(link);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(long id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}