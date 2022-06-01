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
  public class UserProductImageService : IUserProductImageService
  {

    private IHostingEnvironment _env;
    private IUserProductImageRepository _repoProductImage;
    private IUserProductRepository _repoUserProduct;
    private IAzureDataKeys _azureDataKeys;
    private IStorageService _azStorageService;


    public UserProductImageService(
      IHostingEnvironment hostingEnvironment,
      IUserProductRepository userProductRepository,
      IUserProductImageRepository userProductImageRepository,
       IStorageService storage,
      IAzureDataKeys azureDataKeys
      )
    {
      _env = hostingEnvironment;
      _repoProductImage = userProductImageRepository;
      _repoUserProduct = userProductRepository;
    }


    public DataProductImageViewModel Get(int id)
    {
      var productImage = _repoProductImage.Get(id);
      var userProduct = _repoUserProduct.Get(id);
      DataProductImageViewModel userPImages = new DataProductImageViewModel()
      {
        ProductImage = productImage,
        UserProduct = userProduct
      };
      return userPImages;
    }

    public IEnumerable<DataProductImageViewModel> GetAll()
    {
      List<DataProductImageViewModel> poductImageList = new List<DataProductImageViewModel>();
      var productImages = _repoProductImage.GetAll();

      foreach (var item in productImages)
      {
        try
        {
          var viewmodel = Get(item.id);
          poductImageList.Add(viewmodel);
        }
        catch
        {

        }
      }

      return poductImageList;

    }

    public async Task<UserProductImages> Add(FormUserProductImageViewModel input)
    {
      ProductImageMapper mapper = new ProductImageMapper();
      var productImage = mapper.GetProdutImages(input);

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
          return productImage;
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
          productImage.ImageUrl = await url;
        }
      }
      catch
      {
        return productImage;
      }
      _repoProductImage.Add(productImage);


      return productImage;
    }

    public async Task<UserProductImages> Edit(FormUserProductImageViewModel input)
    {
      ProductImageMapper mapper = new ProductImageMapper();
      var productImage = mapper.GetProdutImages(input);

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
          return productImage;
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
          productImage.ImageUrl = await url;
        }
      }
      catch
      {
        return productImage;
      }


      _repoProductImage.Edit(productImage);
      return productImage;
    }

    public UserProductImages Delete(UserProductImages userPImages)
    {
      var answer = _repoProductImage.Delete(userPImages);
      return answer;
    }
  }
}
