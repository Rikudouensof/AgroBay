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
  public class UserProductImagesController : Controller
  {

    private IUserProductRepository _userProdRepo;
    private readonly IUserProductImageRepository _userProdImgRepo;
    private IUserProductImageService _userProdImgService;
    public UserProductImagesController(
      IUserProductRepository userProdRepo,
      IUserProductImageRepository userProdImgRepo,
      IUserProductImageService userProdImgService
      )
    {
      _userProdImgRepo = userProdImgRepo;
      _userProdRepo = userProdRepo;
      _userProdImgService = userProdImgService;
    }

    // GET: UserProductImages
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _userProdImgRepo.GetAll();
      return View( applicationDbContext);
    }

    // GET: UserProductImages/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _userProdImgRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProductImages = _userProdImgRepo.Get(Id);
      if (userProductImages == null)
      {
        return NotFound();
      }

      return View(userProductImages);
    }

    // GET: UserProductImages/Create
    public IActionResult Create()
    {
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name");
      return View();
    }

    // POST: UserProductImages/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormUserProductImageViewModel userProductImages)
    {
      if (ModelState.IsValid)
      {
        await _userProdImgService.Add(userProductImages);
        return RedirectToAction(nameof(Index));
      }
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductImages.UserProductId);
      return View(userProductImages);
    }

    // GET: UserProductImages/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _userProdImgRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProductImages = _userProdImgRepo.Get(Id);
      if (userProductImages == null)
      {
        return NotFound();
      }
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductImages.UserProductId);
      ProductImageMapper mapper = new ProductImageMapper();
      var vm = mapper.GetFormProdutImages(userProductImages);
      return View(vm);
    }

    // POST: UserProductImages/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,  FormUserProductImageViewModel userProductImages)
    {
      if (id != userProductImages.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
         await _userProdImgService.Edit(userProductImages);
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
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductImages.UserProductId);
      return View(userProductImages);
    }

    // GET: UserProductImages/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _userProdImgRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProductImages = _userProdImgRepo.Get(Id);
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
      if (_userProdImgRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.UserProductImages'  is null.");
      }
      var Id = (int)id;
      var userProductImages = _userProdImgRepo.Get(Id);
      if (userProductImages != null)
      {
        _userProdImgRepo.Delete(userProductImages);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool UserProductImagesExists(int id)
    {
      return (_userProdImgRepo.GetAll()?.Any(e => e.id == id)).GetValueOrDefault();
    }
  }
}
