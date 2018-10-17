using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LJWebsite.Models;
using LJWebsite.Models.Entities;

namespace LJWebsite.Controllers
{
    public class FunctionalityController : Controller
    {
        private readonly LjWebContext _context;

        public FunctionalityController(LjWebContext context)
        {
            _context = context;
        }

        // GET: Functionality
        public async Task<IActionResult> Index()
        {
            return View(await _context.Functionality.ToListAsync());
        }

        // GET: Functionality/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionality = await _context.Functionality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionality == null)
            {
                return NotFound();
            }

            return View(functionality);
        }

        // GET: Functionality/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Functionality/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,IsMultiChannel")] Functionality functionality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(functionality);
        }

        // GET: Functionality/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionality = await _context.Functionality.FindAsync(id);
            if (functionality == null)
            {
                return NotFound();
            }
            return View(functionality);
        }

        // POST: Functionality/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,IsMultiChannel")] Functionality functionality)
        {
            if (id != functionality.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functionality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionalityExists(functionality.ID))
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
            return View(functionality);
        }

        // GET: Functionality/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionality = await _context.Functionality
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionality == null)
            {
                return NotFound();
            }

            return View(functionality);
        }

        // POST: Functionality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functionality = await _context.Functionality.FindAsync(id);
            _context.Functionality.Remove(functionality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionalityExists(int id)
        {
            return _context.Functionality.Any(e => e.ID == id);
        }
    }
}
