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
    public class UserProductReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProductReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserProductReviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserProductReviews.Include(u => u.UserProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserProductReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserProductReviews == null)
            {
                return NotFound();
            }

            var userProductReview = await _context.UserProductReviews
                .Include(u => u.UserProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProductReview == null)
            {
                return NotFound();
            }

            return View(userProductReview);
        }

        // GET: UserProductReviews/Create
        public IActionResult Create()
        {
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id");
            return View();
        }

        // POST: UserProductReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Title,Rating,Description,UserProductId,DateSet")] UserProductReview userProductReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProductReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductReview.UserProductId);
            return View(userProductReview);
        }

        // GET: UserProductReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProductReviews == null)
            {
                return NotFound();
            }

            var userProductReview = await _context.UserProductReviews.FindAsync(id);
            if (userProductReview == null)
            {
                return NotFound();
            }
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductReview.UserProductId);
            return View(userProductReview);
        }

        // POST: UserProductReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Title,Rating,Description,UserProductId,DateSet")] UserProductReview userProductReview)
        {
            if (id != userProductReview.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProductReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProductReviewExists(userProductReview.id))
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
            ViewData["UserProductId"] = new SelectList(_context.UserProducts, "id", "id", userProductReview.UserProductId);
            return View(userProductReview);
        }

        // GET: UserProductReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserProductReviews == null)
            {
                return NotFound();
            }

            var userProductReview = await _context.UserProductReviews
                .Include(u => u.UserProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProductReview == null)
            {
                return NotFound();
            }

            return View(userProductReview);
        }

        // POST: UserProductReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserProductReviews == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserProductReviews'  is null.");
            }
            var userProductReview = await _context.UserProductReviews.FindAsync(id);
            if (userProductReview != null)
            {
                _context.UserProductReviews.Remove(userProductReview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProductReviewExists(int id)
        {
          return (_context.UserProductReviews?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
