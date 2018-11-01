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
    public class FixtureFunctionsController : Controller
    {
        private readonly LjWebContext _context;

        public FixtureFunctionsController(LjWebContext context)
        {
            _context = context;
        }

        // GET: FixtureFunctions
        public async Task<IActionResult> Index()
        {
            var ljWebContext = _context.FixtureFunctions.Include(f => f.ControllerFunction).Include(f => f.Fixture);
            return View(await ljWebContext.ToListAsync());
        }

        // GET: FixtureFunctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixtureFunction = await _context.FixtureFunctions
                .Include(f => f.ControllerFunction)
                .Include(f => f.Fixture)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fixtureFunction == null)
            {
                return NotFound();
            }

            return View(fixtureFunction);
        }

        // GET: FixtureFunctions/Create
        public IActionResult Create()
        {
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name");
            ViewData["FixtureID"] = new SelectList(_context.Fixtures, "ID", "ID");
            return View();
        }

        // POST: FixtureFunctions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FixtureID,ControllerFunctionID,Description,MultiChannel")] FixtureFunction fixtureFunction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixtureFunction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", fixtureFunction.ControllerFunctionID);
            ViewData["FixtureID"] = new SelectList(_context.Fixtures, "ID", "ID", fixtureFunction.FixtureID);
            return View(fixtureFunction);
        }

        // GET: FixtureFunctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixtureFunction = await _context.FixtureFunctions.FindAsync(id);
            if (fixtureFunction == null)
            {
                return NotFound();
            }
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", fixtureFunction.ControllerFunctionID);
            ViewData["FixtureID"] = new SelectList(_context.Fixtures, "ID", "ID", fixtureFunction.FixtureID);
            return View(fixtureFunction);
        }

        // POST: FixtureFunctions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FixtureID,ControllerFunctionID,Description,MultiChannel")] FixtureFunction fixtureFunction)
        {
            if (id != fixtureFunction.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixtureFunction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixtureFunctionExists(fixtureFunction.ID))
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
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", fixtureFunction.ControllerFunctionID);
            ViewData["FixtureID"] = new SelectList(_context.Fixtures, "ID", "ID", fixtureFunction.FixtureID);
            return View(fixtureFunction);
        }

        // GET: FixtureFunctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fixtureFunction = await _context.FixtureFunctions
                .Include(f => f.ControllerFunction)
                .Include(f => f.Fixture)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fixtureFunction == null)
            {
                return NotFound();
            }

            return View(fixtureFunction);
        }

        // POST: FixtureFunctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fixtureFunction = await _context.FixtureFunctions.FindAsync(id);
            _context.FixtureFunctions.Remove(fixtureFunction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixtureFunctionExists(int id)
        {
            return _context.FixtureFunctions.Any(e => e.ID == id);
        }
    }
}
