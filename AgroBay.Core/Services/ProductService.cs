using AgroBay.Core.Constants;
using AgroBay.Core.Data;
using AgroBay.Core.Mapping;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class ProductService : IProductService
  {

    private IProductReposiotory _repoProduct;
    private IHostingEnvironment _env;
    private IStorage _azStorageService;
    private ICategories_Repository _repoCat;
    private ISubCategoryRepository _repoSubCat;
    private IDivisions_Repository _repoDiv;

    public ProductService(IProductReposiotory productReposiotory,
      IHostingEnvironment hostingEnvironment,
      IStorage storage,
      ICategories_Repository categories_Repository,
      ISubCategoryRepository subCategoryRepository,
      IDivisions_Repository divisions_Repository

      )

    {
      _repoProduct = productReposiotory;
      _env = hostingEnvironment;
      _azStorageService = storage;
      _repoCat = categories_Repository;
      _repoSubCat = subCategoryRepository;
      _repoDiv = divisions_Repository;
    }


    public DataProductViewModel Get(int id)
    {
      var product = _repoProduct.Get(id);
      var subCategory = _repoSubCat.Get(product.SubCategoryId);
      var category = _repoCat.Get(subCategory.CategoriesId);
      var division = _repoDiv.Get(category.Id);

      DataProductViewModel dataProductViewModel = new DataProductViewModel()
      {
        Division = division,
        Category = category,
        Product = product,
        SubCategory = subCategory
      };
      return dataProductViewModel;
    }

    public IEnumerable<DataProductViewModel> GetAll()
    {
      var products = _repoProduct.GetAll();
      List<DataProductViewModel> dataProductViewModels = new List<DataProductViewModel>();

      foreach (var item in products)
      {
        try
        {
          var dataproduct = Get(item.Id);
          dataProductViewModels.Add(dataproduct);
        }
        catch
        {

        }
      }

      return dataProductViewModels;
    }

    public async Task<Product> Add(FormProductViewModel input)
    {
      ProductMapper productMapper = new ProductMapper();
      var product = productMapper.GetProduct(input);
      try
      {
        var iscorrectformat = false;
        string uniqueName = null;
        string filePath = null;
        FileInfo fi = new FileInfo(input.File.FileName);

        var actualextension = fi.Extension;
        var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
        foreach (var imageExtension in imageextensions)
        {
          if (imageExtension == actualextension.ToUpper())
          {
            iscorrectformat = true;
          }
        }
        if (iscorrectformat == false)
        {
          return product;
        }

        if (input.File is not null)
        {

          var fileName = input.File.FileName;
          var blobname = AzureDataKeys.blob_background;
          string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
          uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
          filePath = Path.Combine(uploadsFolder, uniqueName);

          var file = new FileStream(filePath, FileMode.Create);
          input.File.CopyTo(file);
          var url = _azStorageService.UploadFileToStorage(file, fileName, blobname, AzureDataKeys.GetStorageArguement());
          product.ImageUrl = await url;
        }
      }
      catch
      {
        return product;
      }


      _repoProduct.Add(product);
      return product;
    }

    public async Task<Product> Edit(FormProductViewModel input)
    {
      ProductMapper productMapper = new ProductMapper();
      var product = productMapper.GetProduct(input);

      try
      {
        var iscorrectformat = false;
        string uniqueName = null;
        string filePath = null;
        FileInfo fi = new FileInfo(input.File.FileName);

        var actualextension = fi.Extension;
        var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
        foreach (var imageExtension in imageextensions)
        {
          if (imageExtension == actualextension.ToUpper())
          {
            iscorrectformat = true;
          }
        }
        if (iscorrectformat == false)
        {
          return product;
        }

        if (input.File is not null)
        {

          var fileName = input.File.FileName;
          var blobname = AzureDataKeys.blob_background;
          string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
          uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
          filePath = Path.Combine(uploadsFolder, uniqueName);

          var file = new FileStream(filePath, FileMode.Create);
          input.File.CopyTo(file);
          var url = _azStorageService.UploadFileToStorage(file, fileName, blobname, AzureDataKeys.GetStorageArguement());
          product.ImageUrl = await url;
        }
      }
      catch
      {
        return product;
      }
      _repoProduct.Edit(product);
      return product;
    }

    public Product Delete(Product product)
    {
      _repoProduct.Delete(product);
      return product;
    }
  }
}
