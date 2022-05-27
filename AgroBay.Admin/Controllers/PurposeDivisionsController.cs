using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroBay.Admin.Data;
using AgroBay.Admin.Model;

namespace AgroBay.Admin.Controllers
{
    public class PurposeDivisionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurposeDivisionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurposeDivisions
        public async Task<IActionResult> Index()
        {
              return _context.PurposeDivisions != null ? 
                          View(await _context.PurposeDivisions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PurposeDivisions'  is null.");
        }

        // GET: PurposeDivisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PurposeDivisions == null)
            {
                return NotFound();
            }

            var purposeDivision = await _context.PurposeDivisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purposeDivision == null)
            {
                return NotFound();
            }

            return View(purposeDivision);
        }

        // GET: PurposeDivisions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurposeDivisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PurposeDivision purposeDivision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purposeDivision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purposeDivision);
        }

        // GET: PurposeDivisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PurposeDivisions == null)
            {
                return NotFound();
            }

            var purposeDivision = await _context.PurposeDivisions.FindAsync(id);
            if (purposeDivision == null)
            {
                return NotFound();
            }
            return View(purposeDivision);
        }

        // POST: PurposeDivisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PurposeDivision purposeDivision)
        {
            if (id != purposeDivision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purposeDivision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurposeDivisionExists(purposeDivision.Id))
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
            return View(purposeDivision);
        }

        // GET: PurposeDivisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PurposeDivisions == null)
            {
                return NotFound();
            }

            var purposeDivision = await _context.PurposeDivisions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purposeDivision == null)
            {
                return NotFound();
            }

            return View(purposeDivision);
        }

        // POST: PurposeDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PurposeDivisions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PurposeDivisions'  is null.");
            }
            var purposeDivision = await _context.PurposeDivisions.FindAsync(id);
            if (purposeDivision != null)
            {
                _context.PurposeDivisions.Remove(purposeDivision);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurposeDivisionExists(int id)
        {
          return (_context.PurposeDivisions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
