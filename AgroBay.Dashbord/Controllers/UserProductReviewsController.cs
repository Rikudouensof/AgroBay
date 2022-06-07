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
  public class UserProductReviewsController : Controller
  {

    private IUserProductRepository _userProdRepo;
    private readonly IUserProductReviewRepository _userProdRevRepo;
    private IUserProductReviewService _userProdRevService;
    public UserProductReviewsController(
      IUserProductRepository userProdRepo,
      IUserProductReviewRepository userProdRevRepo,
      IUserProductReviewService userProdRevService
      )
    {
      _userProdRepo = userProdRepo;
      _userProdRevRepo = userProdRevRepo;
      _userProdRevService = userProdRevService;
      
    }

    // GET: UserProductReviews
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _userProdRevRepo.GetAll();
      return View(applicationDbContext);
    }

    // GET: UserProductReviews/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _userProdRevRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProductReview = _userProdRevRepo.Get(Id);
      if (userProductReview == null)
      {
        return NotFound();
      }

      return View(userProductReview);
    }

    // GET: UserProductReviews/Create
    public IActionResult Create()
    {
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name");
      return View();
    }

    // POST: UserProductReviews/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create( FormUserProductReviewViewModel userProductReview)
    {
      if (ModelState.IsValid)
      {
        _userProdRevService.Add(userProductReview);
        return RedirectToAction(nameof(Index));
      }
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductReview.UserProductId);
      return View(userProductReview);
    }

    // GET: UserProductReviews/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _userProdRevRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userProductReview =  _userProdRevRepo.Get(Id);
      if (userProductReview == null)
      {
        return NotFound();
      }
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductReview.UserProductId);
      ProductRatingMapper mapper = new ProductRatingMapper();
      var vm = mapper.GetFormProductRatingMapper(userProductReview);
      return View(vm);
    }

    // POST: UserProductReviews/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,  FormUserProductReviewViewModel userProductReview)
    {
      if (id != userProductReview.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _userProdRevService.Edit(userProductReview);
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
      ViewData["UserProductId"] = new SelectList(_userProdRepo.GetAll(), "id", "Name", userProductReview.UserProductId);
      return View(userProductReview);
    }

    // GET: UserProductReviews/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _userProdRevRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id; 
      var userProductReview = _userProdRevRepo.Get(Id);

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
      if (_userProdRevRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.UserProductReviews'  is null.");
      }
      var Id = (int)id;
      var userProductReview = _userProdRevRepo.Get(Id);
      if (userProductReview != null)
      {
        _userProdRevRepo.Delete(userProductReview);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool UserProductReviewExists(int id)
    {
      return (_userProdRevRepo.GetAll()?.Any(e => e.id == id)).GetValueOrDefault();
    }
  }
}
