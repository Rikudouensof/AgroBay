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

    public static string key_1 = "SsC5z1uKZZQQR1BeRBW4U5dxo+4N8s/UBlaoxER26ZujNyOGP0/S4hDgDib0boROIKMiaaVyEBlrBK8+hiYBLw==";

    public static string connection_string = "DefaultEndpointsProtocol=https;AccountName=lusatiaestorage;AccountKey=SsC5z1uKZZQQR1BeRBW4U5dxo+4N8s/UBlaoxER26ZujNyOGP0/S4hDgDib0boROIKMiaaVyEBlrBK8+hiYBLw==;EndpointSuffix=core.windows.net";

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
