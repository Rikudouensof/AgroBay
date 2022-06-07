using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroBay.Core.Model;
using AgroBay.Core.Data;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.ViewModel;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.Mapping;
using Microsoft.AspNetCore.Authorization;

namespace AgroBay.DBTes.Controllers
{

  [Authorize]
  public class CategoriesController : Controller
  {
    private readonly ICategories_Repository _catRepo;
    private readonly IDivisions_Repository _divRepo;
    private ICategoriesService _catService;
    public CategoriesController(ICategories_Repository catRepo, IDivisions_Repository divRepo, ICategoriesService catService)
    {
      _catRepo = catRepo;
      _divRepo = divRepo;
            _catService = catService;
    }

    // GET: Categories
    public  ActionResult Index()
    {
      List<Category> applicationDbContext = _catRepo.GetAll().ToList();
      return View(applicationDbContext);
    }

    // GET: Categories/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _catRepo.GetAll == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var category = _catRepo.Get(Id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
      ViewData["PurposeDivisionId"] = new SelectList(_divRepo.GetAll(), "Id", "Name");
      return View();
    }

    // POST: Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormCategoryViewModel formCategory)
    {

      if (ModelState.IsValid)
      {

        var result = _catService.AddAsync(formCategory);
        return RedirectToAction(nameof(Index));
      }
      ViewData["PurposeDivisionId"] = new SelectList(_divRepo.GetAll(), "Id", "Name", formCategory.PurposeDivisionId);
      return View(formCategory);
    }

    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _catRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var category = _catRepo.Get(Id);
      if (category == null)
      {
        return NotFound();
      }
      ViewData["PurposeDivisionId"] = new SelectList(_divRepo.GetAll(), "Id", "Id", category.PurposeDivisionId);
      CategoryMapper mapper = new CategoryMapper();
      var FormCategory = mapper.GetFormCategory(category);


      return View(FormCategory);
    }

    // POST: Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,  FormCategoryViewModel formCategory)
    {
      if (id != formCategory.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          var result = await _catService.Edit(formCategory);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CategoryExists(formCategory.Id))
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
      ViewData["PurposeDivisionId"] = new SelectList(_divRepo.GetAll(), "Id", "Name", formCategory.PurposeDivisionId);
      return View(formCategory);
    }

    // GET: Categories/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _catRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var category = _catRepo.Get(Id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    // POST: Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_catRepo.GetAll == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
      }
      var category = _catRepo.Get(id);
      if (category != null)
      {
        _catRepo.DeleteCategory(category);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool CategoryExists(int id)
    {
      bool isExist = false;
      var context = _catRepo.Get(id);
      if (context is not null)
      {
        isExist = true;
      }

      return isExist;
    }
  }
}
