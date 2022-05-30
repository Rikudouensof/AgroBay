using AgroBay.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Constants
{
  public class AzureDataKeys
  {

    public static string name = "lusatiaestorage";

    public static string key_1 = "SsCw==";

    public static string connection_string = "Defaultdows.net";

    public static string blob_profile_picture = "profilepictures";
    public static string blob_background = "backgrounds";
    public static string blob_files = "files";

    public static StorageArguement GetStorageArguement()
    {
      StorageArguement storage = new StorageArguement()
      {
        AzureContainerName = name,
        AzureNameKeyKey = key_1,
        ConnectionString = connection_string,
        Pictures = blob_background,
        ProfilePicture = blob_profile_picture, 
        Video = blob_files,
      };
      return storage;
    }
  }

  
}
