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
    public class UserProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserProducts.Include(u => u.Product).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserProducts == null)
            {
                return NotFound();
            }

            var userProduct = await _context.UserProducts
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProduct == null)
            {
                return NotFound();
            }

            return View(userProduct);
        }

        // GET: UserProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ProductId,UserId")] UserProduct userProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", userProduct.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProduct.UserId);
            return View(userProduct);
        }

        // GET: UserProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserProducts == null)
            {
                return NotFound();
            }

            var userProduct = await _context.UserProducts.FindAsync(id);
            if (userProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", userProduct.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProduct.UserId);
            return View(userProduct);
        }

        // POST: UserProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ProductId,UserId")] UserProduct userProduct)
        {
            if (id != userProduct.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProductExists(userProduct.id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", userProduct.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userProduct.UserId);
            return View(userProduct);
        }

        // GET: UserProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserProducts == null)
            {
                return NotFound();
            }

            var userProduct = await _context.UserProducts
                .Include(u => u.Product)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.id == id);
            if (userProduct == null)
            {
                return NotFound();
            }

            return View(userProduct);
        }

        // POST: UserProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserProducts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserProducts'  is null.");
            }
            var userProduct = await _context.UserProducts.FindAsync(id);
            if (userProduct != null)
            {
                _context.UserProducts.Remove(userProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserProductExists(int id)
        {
          return (_context.UserProducts?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
