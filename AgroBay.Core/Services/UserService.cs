using AgroBay.Core.Constants;
using AgroBay.Core.Constants.Interface;
using AgroBay.Core.Data;
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
  public class UserService : IUserService
  {
    private IHostingEnvironment _env;
    private IUserRepository _repoUser;
    private IUserProductService _serviceUsSer;
    private IAzureDataKeys _azureDataKeys;
    private IStorageService _azStorageService;

    public UserService(
      IHostingEnvironment env,
      IUserRepository userRepository,
      IUserProductService userProduct,
       IStorageService storage,
      IAzureDataKeys azureDataKeys
      )
    {
      _env = env;
      _azStorageService = storage;
      _repoUser = userRepository;
      _serviceUsSer = userProduct;
      _azStorageService = storage;
      _azureDataKeys = azureDataKeys;
    }

    public DataUserViewModel Get(string id)
    {
      var user = _repoUser.Get(id);
      var allUserProduct = _serviceUsSer.GetAll();
      var filteredVM = allUserProduct.Where(m => m.ProductUser.UserId == id);
      DataUserViewModel dataUserViewModel = new DataUserViewModel()
      {
        User = user,
        dataUserProductViewModels = filteredVM
      };

      return dataUserViewModel;
    }

    public IEnumerable<DataUserViewModel> GetAll()
    {
      var allusers = _repoUser.GetAll();
      List<DataUserViewModel> vms = new List<DataUserViewModel>();
      foreach (var item in allusers)
      {
        try
        {
          var vm = Get(item.Id);
          vms.Add(vm);
        }
        catch
        {

        }
      }

      return vms;
    }



    public async Task<User> Edit(FormUserViewModel user)
    {
      var dbUser = _repoUser.Get(user.Id);
      dbUser.About = user.About;
      dbUser.FirstName = user.FirstName;
      dbUser.MiddleName = user.MiddleName;
      dbUser.LastName = user.LastName;
      dbUser.PhoneNumber = user.PhoneNumber;
      dbUser.DisplayName = user.DisplayName;
      try
      {
        var iscorrectformat = false;
        string uniqueName = null;
        string filePath = null;
        FileInfo fi = new FileInfo(user.File.FileName);

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
          return dbUser;
        }

        if (user.File is not null)
        {

          var fileName = user.File.FileName;
          var blobname = _azureDataKeys.GetStorageArguement().ProfilePicture;
          string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
          uniqueName = Guid.NewGuid().ToString() + "_" + user.File.FileName;
          filePath = Path.Combine(uploadsFolder, uniqueName);

          var file = new FileStream(filePath, FileMode.Create);
          user.File.CopyTo(file);
          var url = _azStorageService.UploadFileToStorage(file, fileName, blobname);
          dbUser.ImageUrl = await url;
        }
      }
      catch
      {
        return dbUser;
      }
      var processeduser = _repoUser.Edit(dbUser);

      return processeduser;
    }





  }
}
