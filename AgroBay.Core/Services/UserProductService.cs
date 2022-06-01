using AgroBay.Core.Constants;
using AgroBay.Core.Constants.Interface;
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
  public class UserProductService : IUserProductService
  {

    private IHostingEnvironment _env;
    private IProductService _serviceProduct;
    private IUserProductRepository _repoUserProduct;
    private IAzureDataKeys _azureDataKeys;
    private IStorageService _azStorageService;

    public UserProductService(
      IHostingEnvironment env, 
      IProductService productService,
      IUserProductRepository userProductRepository,
      IStorageService storage,
      IAzureDataKeys azureDataKeys

      )
    {
      _env = env;
      _serviceProduct = productService;
      _repoUserProduct = userProductRepository;
      _azStorageService = storage;
      _azureDataKeys = azureDataKeys;
    }


    public DataUserProductViewModel Get(int id)
    {
      var userProduct = _repoUserProduct.Get(id);
      var productDetails = _serviceProduct.Get(userProduct.ProductId);

      DataUserProductViewModel vm = new DataUserProductViewModel()
      {
        ProductUser = userProduct,
        Division = productDetails.Division,
        Category = productDetails.Category,
        Product = productDetails.Product,
        SubCategory = productDetails.SubCategory
      };
      return vm;
    }

    public IEnumerable<DataUserProductViewModel> GetAll()
    {
      var allUserProduct = _repoUserProduct.GetAll();
      List<DataUserProductViewModel> vms = new List<DataUserProductViewModel>();
      foreach (var item in allUserProduct)
      {
        try
        {
          var vm = Get(item.id);
          vms.Add(vm);
        }
        catch
        {

        }
      }

      return vms;
    }

    public async Task<UserProduct> Add(FormUserProductViewModel input)
    {
      UserProductMapper mapper = new UserProductMapper();
      var userProduct = mapper.GetUserProduct(input);

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
          return userProduct;
        }

        if (input.File is not null)
        {

          var fileName = input.File.FileName;
          var blobname = _azureDataKeys.GetStorageArguement().Pictures;
          string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
          uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
          filePath = Path.Combine(uploadsFolder, uniqueName);

          var file = new FileStream(filePath, FileMode.Create);
          input.File.CopyTo(file);
          var url = _azStorageService.UploadFileToStorage(file, fileName, blobname);
          userProduct.ImageUrl = await url;
        }
      }
      catch
      {
        return userProduct;
      }

      var output = _repoUserProduct.Add(userProduct);
      return userProduct;
    }

    public async Task<UserProduct> Edit(FormUserProductViewModel input)
    {
      UserProductMapper mapper = new UserProductMapper();
      var userProduct = mapper.GetUserProduct(input);
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
          return userProduct;
        }

        if (input.File is not null)
        {

          var fileName = input.File.FileName;
          var blobname = _azureDataKeys.GetStorageArguement().Pictures;
          string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
          uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
          filePath = Path.Combine(uploadsFolder, uniqueName);

          var file = new FileStream(filePath, FileMode.Create);
          input.File.CopyTo(file);
          var url = _azStorageService.UploadFileToStorage(file, fileName, blobname);
          userProduct.ImageUrl = await url;
        }
      }
      catch
      {
        return userProduct;
      }

      var output = _repoUserProduct.Edit(userProduct);
      return userProduct;
    }

    public UserProduct Delete(UserProduct userProduct)
    {
      var output = _repoUserProduct.Delete(userProduct);
      return output;
    }
  }
}
