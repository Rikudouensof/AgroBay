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
  public class SubCategoriesController : Controller
  {
    private readonly ISubCategoryRepository _subCatRepo;
    private readonly ICategories_Repository _catRepo;
    private ISubCategoryService _subCatService;

    public SubCategoriesController(ISubCategoryRepository subCatRepo, ICategories_Repository catRepo, ISubCategoryService subCatService)
    {
      _catRepo = catRepo;
      _subCatRepo = subCatRepo;
      _subCatService = subCatService;
    }

    // GET: SubCategories
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _subCatRepo.GetAll();
      return View(applicationDbContext);
    }

    // GET: SubCategories/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _subCatRepo.GetAll() == null)
      {
        return NotFound();
      }

      var Id = (int)id;
      var subCategory = _subCatRepo.Get(Id);
      if (subCategory == null)
      {
        return NotFound();
      }

      return View(subCategory);
    }

    // GET: SubCategories/Create
    public IActionResult Create()
    {
      ViewData["CategoriesId"] = new SelectList(_catRepo.GetAllList(), "Id", "Name");
      return View();
    }

    // POST: SubCategories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormSubCategoryViewModel subCategory)
    {
      if (ModelState.IsValid)
      {

        await _subCatService.Add(subCategory);
        return RedirectToAction(nameof(Index));
      }
      ViewData["CategoriesId"] = new SelectList(_catRepo.GetAllList(), "Id", "Name", subCategory.CategoriesId);
      
      return View(subCategory);
    }

    // GET: SubCategories/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _subCatRepo.GetAll() == null)
      {
        return NotFound();
      }
      int Id = (int)id;
      var subCategory = _subCatRepo.Get(Id);
      if (subCategory == null)
      {
        return NotFound();
      }
      ViewData["CategoriesId"] = new SelectList(_catRepo.GetAllList(), "Id", "Name", subCategory.CategoriesId);
      SubCategoryMapper mapper = new SubCategoryMapper();
      var context = mapper.GetFormSubCategory(subCategory);
      return View(context);
    }

    // POST: SubCategories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,FormSubCategoryViewModel subCategory)
    {
      if (id != subCategory.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _subCatService.Edit(subCategory);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!SubCategoryExists(subCategory.Id))
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
      ViewData["CategoriesId"] = new SelectList(_catRepo.GetAllList(), "Id", "Name", subCategory.CategoriesId);
      return View(subCategory);
    }

    // GET: SubCategories/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _subCatRepo.GetAll() == null)
      {
        return NotFound();
      }
      int Id = (int)id;
      var subCategory = _subCatRepo.Get(Id);
      if (subCategory == null)
      {
        return NotFound();
      }

      return View(subCategory);
    }

    // POST: SubCategories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_subCatRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.SubCategories'  is null.");
      }
      var subCategory = _subCatRepo.Get(id);
      if (subCategory != null)
      {
        _subCatRepo.Delete(subCategory);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool SubCategoryExists(int id)
    {
      bool isExist = false;
      var context = _subCatRepo.Get(id);
      if (context is not null)
      {
        isExist = true;
      }

      return isExist;
    }
  }
}
