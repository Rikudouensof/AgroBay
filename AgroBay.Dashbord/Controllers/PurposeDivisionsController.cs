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

namespace AgroBay.DBTes.Controllers
{
  public class PurposeDivisionsController : Controller
  {
    private IDivisions_Repository _divRepo;
    private IDivisions_Service _divService;


    public PurposeDivisionsController(IDivisions_Repository divRepo, IDivisions_Service divService)
    {
      _divRepo = divRepo;
      _divService = divService;
    }

    // GET: PurposeDivisions
    public async Task<IActionResult> Index()
    {
      IEnumerable<PurposeDivision> purposeDivisions = _divRepo.GetAll();
      return _divRepo.GetAll() != null ?
                  View(purposeDivisions) :
                  Problem("Entity set 'Purpose Divisions'  is null.");
    }

    // GET: PurposeDivisions/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _divRepo.GetAll() == null)
      {
        return NotFound();
      }

      var Id = (int)id;
      var purposeDivision = _divRepo.Get(Id);
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
    public async Task<IActionResult> Create(FormPurposeDivisionViewModel formPurposeDivision)
    {
      if (ModelState.IsValid)
      {
        var output = _divService.Add(formPurposeDivision);
        return RedirectToAction(nameof(Index));
      }
      return View(formPurposeDivision);
    }

    // GET: PurposeDivisions/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _divRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var purposeDivision = _divRepo.Get(Id);
      if (purposeDivision == null)
      {
        return NotFound();
      }
      FormPurposeDivisionViewModel vm = new FormPurposeDivisionViewModel()
      {
          Id = purposeDivision.Id,
          Name = purposeDivision.Name
      };
      return View(vm);
    }

    // POST: PurposeDivisions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FormPurposeDivisionViewModel formPurposeDivision)
    {
      if (id != formPurposeDivision.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _divService.Add(formPurposeDivision);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PurposeDivisionExists((int)formPurposeDivision.Id))
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
      return View(formPurposeDivision);
    }

    // GET: PurposeDivisions/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _divRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var purposeDivision = _divRepo.Get(Id);
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
      if (_divRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.PurposeDivisions'  is null.");
      }
      var purposeDivision = _divRepo.Get(id);
      if (purposeDivision != null)
      {
        _divRepo.Delete(purposeDivision);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool PurposeDivisionExists(int id)
    {
      bool isExist = false;
      var context = _divRepo.Get(id);
      if (context is not null)
      {
        isExist = true;
      }

      return isExist;


    }
  }
}
