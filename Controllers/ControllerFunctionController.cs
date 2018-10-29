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
    public class ControllerFunctionController : Controller
    {
        private readonly LjWebContext _context;

        public ControllerFunctionController(LjWebContext context)
        {
            _context = context;
        }

        // GET: ControllerFunction
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControllerFunctions.ToListAsync());
        }

        // GET: ControllerFunction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controllerFunction = await _context.ControllerFunctions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controllerFunction == null)
            {
                return NotFound();
            }

            return View(controllerFunction);
        }

        // GET: ControllerFunction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ControllerFunction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] ControllerFunction controllerFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controllerFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(controllerFunction);
        }

        // GET: ControllerFunction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controllerFunction = await _context.ControllerFunctions.FindAsync(id);
            if (controllerFunction == null)
            {
                return NotFound();
            }
            return View(controllerFunction);
        }

        // POST: ControllerFunction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] ControllerFunction controllerFunction)
        {
            if (id != controllerFunction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controllerFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControllerFunctionExists(controllerFunction.ID))
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
            return View(controllerFunction);
        }

        // GET: ControllerFunction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controllerFunction = await _context.ControllerFunctions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (controllerFunction == null)
            {
                return NotFound();
            }

            return View(controllerFunction);
        }

        // POST: ControllerFunction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controllerFunction = await _context.ControllerFunctions.FindAsync(id);
            _context.ControllerFunctions.Remove(controllerFunction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControllerFunctionExists(int id)
        {
            return _context.ControllerFunctions.Any(e => e.ID == id);
        }
    }
}
