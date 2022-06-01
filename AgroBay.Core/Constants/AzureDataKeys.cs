using AgroBay.Core.Constants.Interface;
using AgroBay.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Constants
{
  public class AzureDataKeys : IAzureDataKeys
  {
    private readonly IConfiguration _config;
    public AzureDataKeys(IConfiguration configuration)
    {
      _config = configuration;
    }



    public StorageArguement GetStorageArguement()
    {
      StorageArguement storage = new StorageArguement()
      {
        AzureContainerName = _config["AzureStorage:Name"],
        AzureNameKeyKey = _config["AzureStorage:Key"],
        ConnectionString = _config["AzureStorage:ConnString"],
        Pictures = _config["AzureStorage:Picture"],
        ProfilePicture = _config["AzureStorage:ProfilePicture"],
        Video = _config["AzureStorage:Files"],
      };
      return storage;
    }



  }


}
