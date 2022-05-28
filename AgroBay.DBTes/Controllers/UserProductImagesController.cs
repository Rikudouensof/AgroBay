using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroBay.Core.Model;
using AgroBay.DBTes.Data;

namespace AgroBay.DBTes.Controllers
{
    public class UserProductImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProductImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserProductImages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserProductImages.Include(u => u.UserProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserProductImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserProductImages == null)
            {
                return NotFound();
            }

            var userProductImages = await _context.UserProductImages
                .Include(u => u.UserProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProductImages == null)
            {
                return NotFound();
            }

            return View(userProductImages);
        }

        // GET: UserProductImages/Create
        public IActionResult Create()
        {
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id");
            return View();
        }

        // POST: UserProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ImageUrl,DateAdded,UserProductId")] UserProductImages userProductImages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProductImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductImages.UserProductId);
            return View(userProductImages);
        }

        // GET: UserProductImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProductImages == null)
            {
                return NotFound();
            }

            var userProductImages = await _context.UserProductImages.FindAsync(id);
            if (userProductImages == null)
            {
                return NotFound();
            }
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductImages.UserProductId);
            return View(userProductImages);
        }

        // POST: UserProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ImageUrl,DateAdded,UserProductId")] UserProductImages userProductImages)
        {
            if (id != userProductImages.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProductImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProductImagesExists(userProductImages.id))
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
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductImages.UserProductId);
            return View(userProductImages);
        }

        // GET: UserProductImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserProductImages == null)
            {
                return NotFound();
            }

            var userProductImages = await _context.UserProductImages
                .Include(u => u.UserProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProductImages == null)
            {
                return NotFound();
            }

            return View(userProductImages);
        }

        // POST: UserProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserProductImages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserProductImages'  is null.");
            }
            var userProductImages = await _context.UserProductImages.FindAsync(id);
            if (userProductImages != null)
            {
                _context.UserProductImages.Remove(userProductImages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProductImagesExists(int id)
        {
          return (_context.UserProductImages?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
