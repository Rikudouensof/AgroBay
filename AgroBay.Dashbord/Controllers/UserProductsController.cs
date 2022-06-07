using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.ViewModel;
using AgroBay.Core.Mapping;
using Microsoft.AspNetCore.Authorization;

namespace AgroBay.DBTes.Controllers
{


  [Authorize]
  public class UserProductsController : Controller
  {
    private IUserProductRepository _userProdRepo;
    private IUserProductService _userProdService;
    private IProductReposiotory _prodRepo;
    private IUserRepository _userRepo;

    public UserProductsController(
      IUserProductRepository userProdRepo,
      IUserProductService userProdService,
      IProductReposiotory prodRepo,
      IUserRepository userRepo
      )
    {
      _prodRepo = prodRepo;
      _userProdRepo = userProdRepo;
      _userProdService = userProdService;
      _userRepo = userRepo;
    }

    // GET: UserProducts
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _userProdRepo.GetAll();
      return View(applicationDbContext);
    }

    // GET: UserProducts/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _userProdRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProduct = _userProdRepo.Get(Id);
      if (userProduct == null)
      {
        return NotFound();
      }

      return View(userProduct);
    }

    // GET: UserProducts/Create
    public IActionResult Create()
    {
      ViewData["ProductId"] = new SelectList(_prodRepo.GetAllList(), "Id", "Name");
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName");
      return View();
    }

    // POST: UserProducts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create( FormUserProductViewModel userProduct)
    {
      if (ModelState.IsValid)
      {
        await _userProdService.Add(userProduct);
        return RedirectToAction(nameof(Index));
      }
      ViewData["ProductId"] = new SelectList(_prodRepo.GetAllList(), "Id", "Name", userProduct.ProductId);
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", userProduct.UserId);
      return View(userProduct);
    }

    // GET: UserProducts/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _userProdRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProduct = _userProdRepo.Get(Id);
      if (userProduct == null)
      {
        return NotFound();
      }
      ViewData["ProductId"] = new SelectList(_prodRepo.GetAllList(), "Id", "Name", userProduct.ProductId);
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", userProduct.UserId);
      UserProductMapper mapper = new UserProductMapper();
      var vm = mapper.GetFormUserProduct(userProduct);



      return View(vm);
    }

    // POST: UserProducts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,  FormUserProductViewModel userProduct)
    {
      if (id != userProduct.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
         await _userProdService.Edit(userProduct);
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
      ViewData["ProductId"] = new SelectList(_prodRepo.GetAllList(), "Id", "Name", userProduct.ProductId);
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", userProduct.UserId);
      return View(userProduct);
    }

    // GET: UserProducts/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _userProdRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProduct = _userProdRepo.Get(Id);
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
      if (_userProdRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.UserProducts'  is null.");
      }
      var userProduct = _userProdRepo.Get(id);
      if (userProduct != null)
      {
        _userProdRepo.Delete(userProduct);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool UserProductExists(int id)
    {
      return (_userProdRepo.GetAll()?.Any(e => e.id == id)).GetValueOrDefault();
    }
  }
}
