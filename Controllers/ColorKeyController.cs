using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LJWebsite.Models.Entities;
using LJWebsite.Models;

namespace LJWebsite.Controllers
{
    public class ColorKeyController : Controller
    {
        private readonly LjWebContext _context;

        public ColorKeyController(LjWebContext context)
        {
            _context = context;
        }

        // GET: ColorKey
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColorKeys.ToListAsync());
        }

        // GET: ColorKey/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorKey = await _context.ColorKeys
                .FirstOrDefaultAsync(m => m.ColorID == id);
            if (colorKey == null)
            {
                return NotFound();
            }

            return View(colorKey);
        }

        // GET: ColorKey/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColorKey/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColorID,ColorName")] ColorKey colorKey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorKey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorKey);
        }

        // GET: ColorKey/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorKey = await _context.ColorKeys.FindAsync(id);
            if (colorKey == null)
            {
                return NotFound();
            }
            return View(colorKey);
        }

        // POST: ColorKey/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColorID,ColorName")] ColorKey colorKey)
        {
            if (id != colorKey.ColorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorKeyExists(colorKey.ColorID))
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
            return View(colorKey);
        }

        // GET: ColorKey/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorKey = await _context.ColorKeys
                .FirstOrDefaultAsync(m => m.ColorID == id);
            if (colorKey == null)
            {
                return NotFound();
            }

            return View(colorKey);
        }

        // POST: ColorKey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colorKey = await _context.ColorKeys.FindAsync(id);
            _context.ColorKeys.Remove(colorKey);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorKeyExists(int id)
        {
            return _context.ColorKeys.Any(e => e.ColorID == id);
        }
    }
}
