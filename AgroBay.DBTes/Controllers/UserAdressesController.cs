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
    public class UserAdressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAdressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserAdresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserAdresses.Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserAdresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserAdresses == null)
            {
                return NotFound();
            }

            var userAdress = await _context.UserAdresses
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdress == null)
            {
                return NotFound();
            }

            return View(userAdress);
        }

        // GET: UserAdresses/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserAdresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,MapUrl,UserId")] UserAdress userAdress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAdress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdress.UserId);
            return View(userAdress);
        }

        // GET: UserAdresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAdresses == null)
            {
                return NotFound();
            }

            var userAdress = await _context.UserAdresses.FindAsync(id);
            if (userAdress == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdress.UserId);
            return View(userAdress);
        }

        // POST: UserAdresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,MapUrl,UserId")] UserAdress userAdress)
        {
            if (id != userAdress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAdress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAdressExists(userAdress.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdress.UserId);
            return View(userAdress);
        }

        // GET: UserAdresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAdresses == null)
            {
                return NotFound();
            }

            var userAdress = await _context.UserAdresses
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdress == null)
            {
                return NotFound();
            }

            return View(userAdress);
        }

        // POST: UserAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAdresses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserAdresses'  is null.");
            }
            var userAdress = await _context.UserAdresses.FindAsync(id);
            if (userAdress != null)
            {
                _context.UserAdresses.Remove(userAdress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAdressExists(int id)
        {
          return (_context.UserAdresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
