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
    public class FunctionTemplateController : Controller
    {
        private readonly LjWebContext _context;

        public FunctionTemplateController(LjWebContext context)
        {
            _context = context;
        }

        // GET: FunctionTemplate
        public async Task<IActionResult> Index()
        {
            var ljWebsiteContext = _context.FunctionTemplates.Include(f => f.ControllerFunction);
            return View(await ljWebsiteContext.ToListAsync());
        }

        // GET: FunctionTemplate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplate = await _context.FunctionTemplates
                .Include(f => f.ControllerFunction)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionTemplate == null)
            {
                return NotFound();
            }
            if(functionTemplate.TemplateChannel==null)
            {
                //Create empty List is no data on db
                functionTemplate.TemplateChannel= new List<FunctionTemplateChannel>();
            }
            return View(functionTemplate);
        }

        // GET: FunctionTemplate/Create
        public IActionResult Create()
        {
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name");
            return View();
        }

        // POST: FunctionTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ControllerFunctionID,Description")] FunctionTemplate functionTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", functionTemplate.ControllerFunctionID);
            return View(functionTemplate);
        }

        // GET: FunctionTemplate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplate = await _context.FunctionTemplates.FindAsync(id);
            if (functionTemplate == null)
            {
                return NotFound();
            }
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", functionTemplate.ControllerFunctionID);
            return View(functionTemplate);
        }

        // POST: FunctionTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ControllerFunctionID,Description")] FunctionTemplate functionTemplate)
        {
            if (id != functionTemplate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(functionTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunctionTemplateExists(functionTemplate.ID))
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
            ViewData["ControllerFunctionID"] = new SelectList(_context.ControllerFunctions, "ID", "Name", functionTemplate.ControllerFunctionID);
            return View(functionTemplate);
        }

        // GET: FunctionTemplate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplate = await _context.FunctionTemplates
                .Include(f => f.ControllerFunction)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (functionTemplate == null)
            {
                return NotFound();
            }

            return View(functionTemplate);
        }

        // POST: FunctionTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var functionTemplate = await _context.FunctionTemplates.FindAsync(id);
            _context.FunctionTemplates.Remove(functionTemplate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunctionTemplateExists(int id)
        {
            return _context.FunctionTemplates.Any(e => e.ID == id);
        }

        // GET: FunctionTemplate/AddChannel/3
        public async Task<IActionResult> AddChannel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplate = await _context.FunctionTemplates.FindAsync(id);
            if (functionTemplate == null)
            {
                return NotFound();
            }
            // load dependend Data
            //_context.Entry(functionTemplate).Reference(f=> f.ControllerFunction).Load();
            var x=functionTemplate.ControllerFunction;
            
            //System.Diagnostics.Debug.Assert(functionTemplate.ControllerFunction!=null,"Can't load Controller function");
            // add Channel
            if(functionTemplate.TemplateChannel==null)
            {
                functionTemplate.TemplateChannel=new List<FunctionTemplateChannel>();
            }
            var tmpChannel=new FunctionTemplateChannel();
            tmpChannel.FunctionTemplate=functionTemplate;
            tmpChannel.FunctionTemplateRefID=functionTemplate.ID;
            
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName");
            return View(tmpChannel);

        }

        // POST: FunctionTemplate/AddChannel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddChannel([Bind("FunctionTemplateRefID,ColorKeyId,ValueRangeFrom,ValueRangeTo")] FunctionTemplateChannel functionTemplateChannel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(functionTemplateChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ensure model is fully filled 
            if(functionTemplateChannel.FunctionTemplate==null)
                // load dependend Data
                //_context.Entry(functionTemplateChannel)
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName",functionTemplateChannel.ColorKeyId);
            return View(functionTemplateChannel);
        }


        // GET: FunctionTemplate/EditChannel/3
        public async Task<IActionResult> EditChannel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplateChannel = await _context.FunctionTemplateChannels.FindAsync(id);
            if (functionTemplateChannel == null)
            {
                return NotFound();
            }
            
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName");
            return View(functionTemplateChannel);

        }

        // POST: FunctionTemplate/AddChannel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditChannel([Bind("ID,FunctionTemplateRefID,ColorKeyId,ValueRangeFrom,ValueRangeTo")] FunctionTemplateChannel functionTemplateChannel)
        {
            if (ModelState.IsValid)
            {
                FunctionTemplateChannel temp= await _context.FindAsync<FunctionTemplateChannel>(functionTemplateChannel.ID);
                if(temp == null)
                    return NotFound();
                temp.ColorKeyId=functionTemplateChannel.ColorKeyId;
                temp.ValueRangeFrom=functionTemplateChannel.ValueRangeFrom;
                temp.ValueRangeTo=functionTemplateChannel.ValueRangeTo;
                temp.Channel=functionTemplateChannel.Channel;
                _context.Update(temp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ensure model is fully filled 
            if(functionTemplateChannel.FunctionTemplate==null)
                // load dependend Data
                //_context.Entry(functionTemplateChannel)
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName",functionTemplateChannel.ColorKeyId);
            return View(functionTemplateChannel);
        }

        // GET: FunctionTemplate/DeleteChannel/3
        public async Task<IActionResult> DeleteChannel(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var functionTemplateChannel = await _context.FunctionTemplateChannels.FindAsync(id);
            if (functionTemplateChannel == null)
            {
                return NotFound();
            }
            
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName");
            return View(functionTemplateChannel);

        }

        // POST: FunctionTemplate/AddChannel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChannel([Bind("ID,FunctionTemplateRefID,ColorKeyId,ValueRangeFrom,ValueRangeTo")] FunctionTemplateChannel functionTemplateChannel)
        {
            if (ModelState.IsValid)
            {
                FunctionTemplateChannel temp= await _context.FindAsync<FunctionTemplateChannel>(functionTemplateChannel.ID);
                if(temp == null)
                    return NotFound();
                _context.Remove(temp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ensure model is fully filled 
            if(functionTemplateChannel.FunctionTemplate==null)
                // load dependend Data
                //_context.Entry(functionTemplateChannel)
            ViewData["ColorKeyID"] = new SelectList(_context.ColorKeys, "ColorID", "ColorName",functionTemplateChannel.ColorKeyId);
            return View(functionTemplateChannel);
        }

    }
}
