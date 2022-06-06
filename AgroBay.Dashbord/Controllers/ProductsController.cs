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

namespace AgroBay.DBTes.Controllers
{
  public class ProductsController : Controller
  {
    private readonly IProductService _prodService;
    private ISubCategoryRepository _subCatRepo;
    private IProductReposiotory _prodRepo;

    public ProductsController(IProductService prodService, IProductReposiotory prodRepo, ISubCategoryRepository subCategoryRepository)
    {
      _prodService = prodService;
      _prodRepo = prodRepo;
      _subCatRepo = subCategoryRepository;
    }

    // GET: Products
    public async Task<IActionResult> Index()
    {
      IEnumerable<Product> applicationDbContext = _prodRepo.GetAll();
      return View(applicationDbContext);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _prodRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var product = _prodRepo.Get(Id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
      ViewData["SubCategoryId"] = new SelectList(_subCatRepo.GetAll(), "Id", "Name");
      return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormProductViewModel product)
    {
      if (ModelState.IsValid)
      {
        _prodService.Add(product);
        return RedirectToAction(nameof(Index));
      }
      ViewData["SubCategoryId"] = new SelectList(_subCatRepo.GetAll(), "Id", "Name", product.SubCategoryId);
      return View(product);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _prodRepo.GetAll() == null)
      {
        return NotFound();
      }
      int Id = (int)id;
      var product = _prodRepo.Get(Id);
      if (product == null)
      {
        return NotFound();
      }
      ViewData["SubCategoryId"] = new SelectList(_subCatRepo.GetAll(), "Id", "Name", product.SubCategoryId);

      ProductMapper mapper = new ProductMapper();
      var vm = mapper.GetFormProduct(product);


      return View(vm);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FormProductViewModel product)
    {
      if (id != product.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _prodService.Edit(product);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProductExists(product.Id))
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
      ViewData["SubCategoryId"] = new SelectList(_subCatRepo.GetAll(), "Id", "Name", product.SubCategoryId);
      return View(product);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _prodRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var product = _prodRepo.Get(Id);
      if (product == null)
      {
        return NotFound();
      }

      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_prodRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
      }
      var product =  _prodRepo.Get(id);
      if (product != null)
      {
        _prodRepo.Delete(product);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
      bool isExist = false;
      var context = _prodRepo.Get(id);
      if (context is not null)
      {
        isExist = true;
      }

      return isExist;
    }
  }
}
