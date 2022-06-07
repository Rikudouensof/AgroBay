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
using Microsoft.AspNetCore.Authorization;

namespace AgroBay.DBTes.Controllers
{


  [Authorize]
  public class UserAdressesController : Controller
  {
    private readonly IUserAddressRepository _userAddressRepo;
    private readonly IUserRepository _userRepo;
    private IUserAddressService _userAddresService;


    public UserAdressesController(IUserAddressRepository userAddressRepo,
        IUserRepository userRepo,
        IUserAddressService userAddresService)
    {
      _userAddresService = userAddresService;
      _userAddressRepo = userAddressRepo;
      _userRepo = userRepo;

    }

    // GET: UserAdresses
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _userAddressRepo.GetAll();
      return View(applicationDbContext);
    }

    // GET: UserAdresses/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _userAddressRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userAdress = _userAddressRepo.Get(Id);

      if (userAdress == null)
      {
        return NotFound();
      }

      return View(userAdress);
    }

    // GET: UserAdresses/Create
    public IActionResult Create()
    {
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName");
      return View();
    }

    // POST: UserAdresses/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FormUserProductAddressViewModel userAdress)
    {
      if (ModelState.IsValid)
      {
        _userAddresService.Add(userAdress);
        return RedirectToAction(nameof(Index));
      }
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", userAdress.UserId);
      return View(userAdress);
    }

    // GET: UserAdresses/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _userAddressRepo.GetAll() == null)
      {
        return NotFound();
      }

      var Id = (int)id;
      var userAdress = _userAddressRepo.Get(Id);
      if (userAdress == null)
      {
        return NotFound();
      }
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", userAdress.UserId);
      FormUserProductAddressViewModel vm = new FormUserProductAddressViewModel()
      {

      };
      return View(vm);
    }

    // POST: UserAdresses/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FormUserProductAddressViewModel input)
    {
      if (id != input.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _userAddresService.Add(input);
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!UserAdressExists(input.Id))
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
      ViewData["UserId"] = new SelectList(_userRepo.GetAll(), "Id", "DisplayName", input.UserId);
      return View(input);
    }

    // GET: UserAdresses/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _userAddressRepo.GetAll() == null)
      {
        return NotFound();
      }
      var Id = (int)id;
      var userAdress = _userAddressRepo.Get(Id);
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
      if (_userAddressRepo.GetAll() == null)
      {
        return Problem("Entity set 'ApplicationDbContext.UserAdresses'  is null.");
      }
      var userAdress = _userAddressRepo.Get(id);
      if (userAdress != null)
      {
        _userAddressRepo.Delete(userAdress);
      }

      return RedirectToAction(nameof(Index));
    }

    private bool UserAdressExists(int id)
    {
      return (_userAddressRepo.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
