using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZBlog.Data;
using ZBlog.Data.Entity;

namespace ZBlog.Areas.Admin.controller
{
    [Area("Admin")]
    public class ConfigController : Controller
    {
        private readonly ZBlogContext _context;

        public ConfigController(ZBlogContext context)
        {
            _context = context;
        }

        // GET: Admin/Config
        public async Task<IActionResult> Index()
        {
            return View(await _context.Configs.ToListAsync());
        }

        // GET: Admin/Config/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var config = await _context.Configs
                .FirstOrDefaultAsync(m => m.Name == id);
            if (config == null)
            {
                return NotFound();
            }

            return View(config);
        }

        // GET: Admin/Config/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Config/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Data")] Data.Entity.Config config)
        {
            if (ModelState.IsValid)
            {
                _context.Add(config);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(config);
        }

        // GET: Admin/Config/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var config = await _context.Configs.FindAsync(id);
            if (config == null)
            {
                return NotFound();
            }
            return View(config);
        }

        // POST: Admin/Config/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Data")] Data.Entity.Config config)
        {
            if (id != config.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(config);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigExists(config.Name))
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
            return View(config);
        }

        // GET: Admin/Config/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var config = await _context.Configs
                .FirstOrDefaultAsync(m => m.Name == id);
            if (config == null)
            {
                return NotFound();
            }

            return View(config);
        }

        // POST: Admin/Config/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var config = await _context.Configs.FindAsync(id);
            _context.Configs.Remove(config);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigExists(string id)
        {
            return _context.Configs.Any(e => e.Name == id);
        }
    }
}
