using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroBay.Core.Data;
using AgroBay.Core.Model;
using AgroBay.Web.ViewModel;
using AgroBay.Core.Tasks;
using AgroBay.Web.Constants;
using AgroBay.Core.Services;

namespace AgroBay.Web.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly AgroBayDbContext _context;
    private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
    private AzureManagement _storage;
    private Storage _storageService;


    public CategoriesController(Microsoft.AspNetCore.Hosting.IHostingEnvironment env,
        AgroBayDbContext context,
        AzureManagement azureManagement,
        Storage storage)
    {
      _context = context;
      _env = env;
      _storage = azureManagement;
      _storageService = storage;
    }

    // GET: Categories
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.Categories.Include(c => c.PurposeDivision);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Categories/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null || _context.Categories == null)
      {
        return NotFound();
      }

      var categories = await _context.Categories
          .Include(c => c.PurposeDivision)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (categories == null)
      {
        return NotFound();
      }

      return View(categories);
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
      ViewData["PurposeDivisionId"] = new SelectList(_context.PurposeDivisions, "Id", "Name");
      return View();
    }

    // POST: Categories/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FileCategoryViewModel categories)
    {
      Category category = new Category();
      categories.ImageUrl = "null";
      if (ModelState.IsValid)
      {
        try
        {

          var iscorrectformat = false;
          string uniqueName = null;
          string filePath = null;
          FileInfo fi = new FileInfo(categories.File.FileName);

          var actualextension = fi.Extension;
          var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
          foreach (var imageExtension in imageextensions)
          {
            if (imageExtension == actualextension)
            {
              iscorrectformat = true;
            }
          }
          if (iscorrectformat == false)
          {
            return View(categories);
          }

          if (categories.File != null)
          {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "ProfilePicture");
            uniqueName = Guid.NewGuid().ToString() + "_" + categories.File.FileName;
            filePath = Path.Combine(uploadsFolder, uniqueName);




            var azureStorageArguement = _storage.GetArguement();
            var fileName = categories.File.FileName;
            var blobname = azureStorageArguement.AzureContainerName;
            var file = new FileStream(filePath, FileMode.Create);
            categories.File.CopyTo(file);
            var url = _storageService.UploadFileToStorage(file, fileName, blobname, azureStorageArguement);
            categories.ImageUrl = await url;



            category.PurposeDivisionId = categories.PurposeDivisionId;
            category.Name = categories.Name;
            category.ImageUrl = categories.ImageUrl;
            category.Description = categories.Description;


          }
        }
        catch
        {

        }
        _context.Add(category);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["PurposeDivisionId"] = new SelectList(_context.PurposeDivisions, "Id", "Name", categories.PurposeDivisionId);
      return View(categories);
    }

    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.Categories == null)
      {
        return NotFound();
      }

      var categories = await _context.Categories.FindAsync(id);
      if (categories == null)
      {
        return NotFound();
      }
      FileCategoryViewModel fileCategoryViewModel = new FileCategoryViewModel()
      {
        Description = categories.Description,
        Name = categories.Name,
        PurposeDivisionId = categories.PurposeDivisionId,
        Id = categories.Id,
        ImageUrl = categories.ImageUrl
      };
      ViewData["PurposeDivisionId"] = new SelectList(_context.PurposeDivisions, "Id", "Name", categories.PurposeDivisionId);
      return View(fileCategoryViewModel);
    }

    // POST: Categories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, FileCategoryViewModel categories)
    {

      if (id != categories.Id)
      {
        return NotFound();
      }
      var category = _context.Categories.Where(m => m.Id ==id).FirstOrDefault();
      categories.ImageUrl = "null";


      if (ModelState.IsValid)
      {
        try
        {
          try
          {

            var iscorrectformat = false;
            string uniqueName = null;
            string filePath = null;
            FileInfo fi = new FileInfo(categories.File.FileName);

            var actualextension = fi.Extension;
            var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
            foreach (var imageExtension in imageextensions)
            {
              if (imageExtension == actualextension)
              {
                iscorrectformat = true;
              }
            }
            if (iscorrectformat == false)
            {
              return View(categories);
            }

            if (categories.File != null)
            {
              string uploadsFolder = Path.Combine(_env.WebRootPath, "ProfilePicture");
              uniqueName = Guid.NewGuid().ToString() + "_" + categories.File.FileName;
              filePath = Path.Combine(uploadsFolder, uniqueName);




              var azureStorageArguement = _storage.GetArguement();
              var fileName = categories.File.FileName;
              var blobname = azureStorageArguement.AzureContainerName;
              var file = new FileStream(filePath, FileMode.Create);
              categories.File.CopyTo(file);
              var url = _storageService.UploadFileToStorage(file, fileName, blobname, azureStorageArguement);
              categories.ImageUrl = await url;



              category.PurposeDivisionId = categories.PurposeDivisionId;
              category.Name = categories.Name;
              category.ImageUrl = categories.ImageUrl;
              category.Description = categories.Description;


            }
          }
          catch
          {

          }
          _context.Update(category);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CategoriesExists(categories.Id))
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
      ViewData["PurposeDivisionId"] = new SelectList(_context.PurposeDivisions, "Id", "Name", categories.PurposeDivisionId);
      return View(categories);
    }

    // GET: Categories/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.Categories == null)
      {
        return NotFound();
      }

      var categories = await _context.Categories
          .Include(c => c.PurposeDivision)
          .FirstOrDefaultAsync(m => m.Id == id);
      if (categories == null)
      {
        return NotFound();
      }

      return View(categories);
    }

    // POST: Categories/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Categories == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
      }
      var categories = await _context.Categories.FindAsync(id);
      if (categories != null)
      {
        _context.Categories.Remove(categories);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CategoriesExists(int id)
    {
      return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
